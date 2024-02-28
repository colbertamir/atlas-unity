using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public TMP_Text timerText; // Reference to the UI Text component to display the timer
    private float startTime; // The time when the timer starts
    private bool timerRunning = true; // Flag to check if the timer is running

    public Color winColor = Color.green; // Color to change to when the timer stops
    public float winFontSize = 60f; // Font size to change to when the timer stops

    void Start()
    {
        startTime = Time.time; // Set the initial start time
    }

    void Update()
    {
        if (timerRunning)
        {
            // Calculate the elapsed time since the timer started
            float elapsedTime = Time.time - startTime;

            // Format the time into minutes, seconds, and milliseconds
            int minutes = (int)(elapsedTime / 60);
            int seconds = (int)(elapsedTime % 60);
            int milliseconds = (int)((elapsedTime * 100) % 100);

            // Update the timer text
            timerText.text = string.Format("{0}:{1:00}.{2:00}", minutes, seconds, milliseconds);
        }
    }

    // Method to stop the timer
    public void StopTimer()
    {
        timerRunning = false;
        timerText.color = winColor; // Change font color to green
        timerText.fontSize = Mathf.RoundToInt(winFontSize); // Increase font size to 60
    }
}
