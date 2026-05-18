using UnityEngine;
using System.Collections.Generic;

public class GameData : MonoBehaviour
{

    private static GameData instance;
    public List<float> bestTimes = new List<float>();  
    public static GameData Instance
    {
        get { return instance; }
    }
    public string leaderboardKey = "LVL.1-";

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        LoadLeaderBoard();
    }

    void LoadLeaderBoard()
    {
        for(int i = 0; i<5; i++)
        {
            float time = PlayerPrefs.GetFloat(leaderboardKey + i, 999.99f);
            bestTimes.Add(time);
        }
    }

    void SaveLeaderBoard()
    {
        for (int i = 0;i<5;i++)
        {
            if(bestTimes.Count >= i)
            PlayerPrefs.SetFloat(leaderboardKey + i, bestTimes[i]);
        }
    }
    public void AddTime(float time)
    {
        bestTimes.Add(time);
        bestTimes.Sort();
        SaveLeaderBoard();
    }
}
