using System.Diagnostics;
using UnityEngine;
using static GameManager;

public class FinishGate : MonoBehaviour
{
    public static event TimerEvent StopRace;
    [SerializeField] private GameObject RaceFinishPanel;

    private void Start()
    {
        RaceFinishPanel.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            StopRace.Invoke();

            RaceFinishPanel.SetActive(true);
        }
    }
}
