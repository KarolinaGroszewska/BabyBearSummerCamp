using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using TMPro;


public class BearController : MonoBehaviour
{
    public GameObject bearController;
    private bool selected;
    public bool Selected
    {
        get => selected;
        set
        {
            selected = value;
            Highlight(value);
        }
    }
    
    //Timer for the minute function - Is in seconds. 
    private const int TIMER = 60;
    //Odds that there will be a reduction in a stat each minute.
    //This SHOULD NOT be less than 3 - or else unintended results will occur!
    private const int RANDOM_CHANCE = 10;
    
    //The main stats for the bears
    private float happiness = 5;
    private float hunger = 5;
    private float energy = 5;
    private Temperament temperment; 

    
    //The GUI connected to a bearObject for testing purposes
    //public TextMeshProUGUI bearText;
    
    //Static Array containing every single temperment, currently only contains two temperments 
    static readonly Temperament[] TEMPERAMENTS = new Temperament[]
    {
        
        new Temperament("Moody", 0.8f, 1, 1),
        new Temperament("Bubbly", 1.2f, 1, 1)

    };

    
    //These are called properties - There are essentially streamlined getter 
    //and setter functions that you can access with pretty UI
    //Example: Bear.Happiness instead of Bear.getHappiness
    //TODO: Rework the temperament formula into one that makes more sense! 
    //Look into reworking the quantity of the stats themselves - Meet with the team for this!
    public float Happiness
    {
        get => happiness;
        set
        {
            //If there is a positive increase, modify the happiness gain by the bear's temperament
            if (value > 0)
            {
                happiness = value * temperment.HappinessMod;
            }
            else
            {
                happiness = value * temperment.HappinessMod; 
            }
            UpdateText();
        }
    }

    public float Hunger
    {
        get => hunger;
        set
        {
            hunger = value * temperment.HungerMod;
            UpdateText();
        }
    }

    public float Energy
    {
        get => energy;
        set
        {
            energy = value * temperment.EnergyMod;
            UpdateText();
        }
    }

   
    // Start is called before the first frame update
    void Start()
    {
        //Sets the temperment 
        temperment = new Temperament(TEMPERAMENTS[(int)Random.Range(0, TEMPERAMENTS.Length)]);
        
        UpdateText();
        StartCoroutine(MinuteUpdate());
    }

    // Show or hide the highlight that shows below the bear when it is selected
    public void Highlight(bool highlight)
    {
        transform.Find("Highlight").GetComponent<SpriteRenderer>().enabled = highlight;
    }

    private void GenerateTemperment()
    {
    }

    // Calls once every minute 
    IEnumerator MinuteUpdate()
    {
        while (true)
        {
            Debug.Log("Starting the Minute Downtime");
            yield return new WaitForSeconds(TIMER);
            
            RandomReduction();
        }
    }
    
    //This function randomly reduces one of the bear's stats
    void RandomReduction()
    {
        int randNum = Random.Range(1, RANDOM_CHANCE);
        switch (randNum)
        {
            case 1:
                Happiness -= 1;
                break;
            case 2:
                Hunger -= 1;
                break;
            case 3:
                Energy -= 1;
                break;
            default:
                Debug.Log("No Value was reduced.");
                break;
        }
    }
    
    //Temp Function that updates a text UI element 
    void UpdateText()
    {
        // bearText.text = "I am a bear!\nHappiness: " + Happiness + "\nHunger: " + Hunger + "\nSleepiness: " + Energy;

    }

    private void OnMouseDown()
    {
        bearController.GetComponent<BearManager>().SelectedBear = this;
    }

}
