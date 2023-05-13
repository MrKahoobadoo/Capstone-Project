using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;

public class StopwatchScript : MonoBehaviour
{
    public float elapsedTime;
    public bool isRunning;
    public string elapsedTimeString;

    public TextMeshProUGUI timeText;
    
    void Start()
    {
        isRunning = true;
    }

    void Update()
    {
        TimeChanger();
        TimePrinter();
    }

    public void TimeChanger()
    {
        if (isRunning)
        {
            elapsedTime += Time.deltaTime;
        }
    }

    public void StartStopwatch()
    {
        isRunning = true;
    }

    public void StopStopwatch()
    {
        isRunning = false;
    }

    public void TimePrinter()
    {

        TimeSpan timeSpan = TimeSpan.FromSeconds(elapsedTime);

        elapsedTimeString = string.Format("{0:D2}:{1:D2}",
            (int)timeSpan.TotalMinutes,
            timeSpan.Seconds);

        timeText.text = elapsedTimeString;

    }
}
