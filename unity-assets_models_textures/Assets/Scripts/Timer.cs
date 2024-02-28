using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public TMP_Text timerText; // Reference to the UI Text component to display the timer
    private float startTime; // The time when the timer starts

    void Start()
    {
        startTime = Time.time; // Set the initial start time
    }

    void Update()
    {
        // Calculate the elapsed time since the timer started
        float elapsedTime = Time.time - startTime;

        // Format the time into minutes, seconds, and milliseconds
        int minutes = (int)(elapsedTime / 60);
        int seconds = (int)(elapsedTime % 60);
        int milliseconds = (int)((elapsedTime * 100) % 100);

        // Update the timer text
        timerText.text = elapsedTime.ToString("0:00.00");
    }
}
