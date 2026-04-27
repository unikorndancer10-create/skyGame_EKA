using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private DateTime raceStart;
    private TimeSpan raceTime;
    private bool racing;
    public delegate void TimerEvent();
    
    private void OnEnable()
    {
        StartGate.StartRace += OnRaceStart;
        FinishGate.StopRace += OnRaceStop;
    }
    void OnRaceStart()
    {
        racing = true;
        raceStart = DateTime.Now;
        Debug.Log("Start!");
    }

    void OnRaceStop()
    {
        racing = false;
        Debug.Log("Finish!");
    }

    private void Update()
    {
        if(racing) 
            raceTime = DateTime.Now - raceStart;
        Debug.Log("Race time " + raceTime);
    }
}
