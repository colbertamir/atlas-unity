using UnityEngine;

public class WinFlag : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Timer timer = FindObjectOfType<Timer>(); // Find the Timer component in the scene
            if (timer != null)
            {
                timer.StopTimer(); // Stop the timer when the player reaches the win flag
            }
        }
    }
}
