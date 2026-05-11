using System;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    private DateTime raceStart;
    private TimeSpan raceTime;
    private TimeSpan penaltyTime;
    private bool racing;

    private TimeSpan bestTime;
    public delegate void TimerEvent();

    [SerializeField] private int penaltyTimeVal = 3;

    [SerializeField] private TMP_Text raceTimeText;
    [SerializeField] private TMP_Text bestTimeText;
    [SerializeField] private string bestTimeKey = "Best Time";
    private void OnEnable()
    {
        StartGate.StartRace += OnRaceStart;
        FinishGate.StopRace += OnRaceStop;
        SlalomFlag.RacePenalty += AddRacePenalty;
    }
    private void Start()
    {
        if (PlayerPrefs.HasKey(bestTimeKey))
        {
            int bestTimeTicks = PlayerPrefs.GetInt(bestTimeKey);
            bestTime = new TimeSpan(bestTimeTicks);
            bestTimeText.text = "BEST TIME" + bestTime.ToString("ss\\:ff");
        }
        else
        {
            bestTime = new TimeSpan(int.MaxValue);
            bestTimeText.text = "BEST TIME: --:--";
        }
    }
    void AddRacePenalty()
    {
        penaltyTime += new TimeSpan(0, 0, penaltyTimeVal);
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
        if(raceTime < bestTime)
        {
            bestTime = raceTime;
            bestTimeText.text = "BEST TIME" + bestTime.ToString("ss\\:ff");
            bestTimeText.color = Color.green;
            PlayerPrefs.SetInt(bestTimeKey, (int)bestTime.Ticks);
            PlayerPrefs.Save();
        }
    }

    private void Update()
    {
        if(racing) 
            raceTime = DateTime.Now - raceStart + penaltyTime;
        Debug.Log("Race time " + raceTime);
        raceTimeText.text = "TIME: " + raceTime.ToString("ss\\:ff");
    }
}
