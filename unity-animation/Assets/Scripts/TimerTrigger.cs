using UnityEngine;

public class TimerTrigger : MonoBehaviour
{
    public Timer timerScript; // Reference to the Timer script component

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            timerScript.enabled = true; // Enable the Timer script to start counting up
        }
    }
}
