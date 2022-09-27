using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearManager : MonoBehaviour
{
    private BearController selectedBear = null;
    public BearController SelectedBear
    {
        get => selectedBear;
        set
        {
            if (selectedBear != null)
            {
                selectedBear.Selected = false;
            }

            selectedBear = value;

            if (selectedBear != null)
            {
                selectedBear.Selected = true;
            }
            SelectedAnyBearThisFrame = true;
        }
    }

    public bool SelectedAnyBearThisFrame = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        if (!SelectedAnyBearThisFrame && Input.GetMouseButtonDown(0)) // Left mouse click
        {
            // This should run before any bear receives the click event
            // Deselect any selected bears
            SelectedBear = null;
        }
        SelectedAnyBearThisFrame = false;
    }
}
