using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using PriorityQueueDemo;

// https://en.wikipedia.org/wiki/A*_search_algorithm

class AStar
{
    static int heuristic(Vector2Int a, Vector2Int b)
    {
        // Manhattan distance (for speed)
        return Math.Abs(a.x - b.x) + Math.Abs(a.y - b.y);
    }

    static int edgeWeight(Vector2Int a, Vector2Int b)
    {
        return 1;
    }

    // It is returned in reverse.
    static IList<Vector2Int> reconstructPath(Dictionary<Vector2Int, Vector2Int> cameFrom, Vector2Int current)
    {
        var totalPath = new List<Vector2Int>();
        totalPath.Add(current);
        while (cameFrom.ContainsKey(current))
        {
            current = cameFrom[current];
            totalPath.Add(current);
        }
        return totalPath;
    }

    static void process(Vector2Int neighbor, Dictionary<Vector2Int, int> gScore, Dictionary<Vector2Int, int> fScore, Dictionary<Vector2Int, Vector2Int> cameFrom, PriorityQueue<int, Vector2Int> openSet, Vector2Int current, Vector2Int goal)
    {
        // d(current,neighbor) is the weight of the edge from current to neighbor
        // tentative_gScore is the distance from start to the neighbor through current
        var tentative_gScore = gScore.GetValueOrDefault(current, int.MaxValue) + edgeWeight(current, neighbor);
        if (tentative_gScore < gScore.GetValueOrDefault(neighbor, int.MaxValue))
        {
            // This path to neighbor is better than any previous one. Record it!
            cameFrom[neighbor] = current;
            gScore[neighbor] = tentative_gScore;
            var oldFScore = fScore.GetValueOrDefault(neighbor, int.MaxValue);
            fScore[neighbor] = tentative_gScore + heuristic(neighbor, goal);
            if (oldFScore == int.MaxValue)
            {
                var neighbor_ = new KeyValuePair<int, Vector2Int>(oldFScore, neighbor);
                if (!openSet.Contains(neighbor_))
                {
                    openSet.Add(neighbor_);
                }
            }
        }
    }

    // Returns the empty list if no path was found between `start` and `goal`.
    // A* finds a path from start to goal.
    // h is the heuristic function. h(n) estimates the cost to reach goal from node n.
    static IList<Vector2Int> A_Star(Vector2Int start, Vector2Int goal, Vector2Int tilemapDimensions)
    {
        // The set of discovered nodes that may need to be (re-)expanded.
        // Initially, only the start node is known.
        // This is usually implemented as a min-heap or priority queue rather than a hash-set.
        var openSet = new PriorityQueue<int, Vector2Int>();
        var fScoreInitial = heuristic(start, goal);
        openSet.Add(new KeyValuePair<int, Vector2Int>(fScoreInitial, start));

        // For node n, cameFrom[n] is the node immediately preceding it on the cheapest path from start
        // to n currently known.
        var cameFrom = new Dictionary<Vector2Int, Vector2Int>();

        // For node n, gScore[n] is the cost of the cheapest path from start to n currently known.
        var gScore = new Dictionary<Vector2Int, int>(); // Assume infinity if not in this map
        gScore[start] = 0;

        // For node n, fScore[n] := gScore[n] + h(n). fScore[n] represents our current best guess as to
        // how cheap a path could be from start to finish if it goes through n.
        var fScore = new Dictionary<Vector2Int, int>(); // Assume infinity if not in this map
        fScore[start] = fScoreInitial;

        while (openSet.Count != 0)
        {
            // This operation can occur in O(Log(N)) time if openSet is a min-heap or a priority queue
            var current = openSet.Peek();
            if (current.Value == goal)
            {
                return reconstructPath(cameFrom, current.Value);
            }

            openSet.Remove(current);
            // For all neighbors that exist:
            if (start.x - 1 >= 0)
            {
                process(new Vector2Int(start.x - 1, start.y), gScore, fScore, cameFrom, openSet, current.Value, goal);
            }
            if (start.x + 1 < tilemapDimensions.x)
            {
                process(new Vector2Int(start.x + 1, start.y), gScore, fScore, cameFrom, openSet, current.Value, goal);
            }
            if (start.y - 1 >= 0)
            {
                process(new Vector2Int(start.x, start.y - 1), gScore, fScore, cameFrom, openSet, current.Value, goal);
            }
            if (start.y + 1 < tilemapDimensions.y)
            {
                process(new Vector2Int(start.x, start.y + 1), gScore, fScore, cameFrom, openSet, current.Value, goal);
            }
        }

        // Open set is empty but goal was never reached
        return new List<Vector2Int>();
    }

}