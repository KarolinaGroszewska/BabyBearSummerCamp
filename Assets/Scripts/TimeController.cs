using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



public class TimeController : MonoBehaviour
{
    //The TMPro text box to display the time on 
    public TextMeshProUGUI timeText;
    private float timer = 0.0f;
    private bool isTimer = false;

    //displays the time on the UI
    void DisplayTime()
    {
        int minutes = Mathf.FloorToInt(timer / 60.0f);
        int seconds = Mathf.FloorToInt(timer - (minutes * 60));
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    
    //attach to play button
    public void StartTimer()
    {
        isTimer = true;
    }

    //attach to pause button
    public void StopTimer()
    {
        isTimer = false;
    }

    public void ResetTimer()
    {
        timer = 0.0f;
    }

   
    void Update()
    {
        if (isTimer)
        {
            timer += Time.deltaTime;
            DisplayTime();
        }
    }



}
