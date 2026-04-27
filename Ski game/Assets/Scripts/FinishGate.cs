using System.Diagnostics;
using UnityEngine;
using static GameManager;

public class FinishGate : MonoBehaviour
{
    public static event TimerEvent StopRace;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            StopRace.Invoke();
        }
    }
}
