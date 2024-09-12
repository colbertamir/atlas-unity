using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreTMP;  // Reference to the TextMeshProUGUI component
    private int score = 0;            // Current score

    void Start()
    {
        // Initialize the score display
        UpdateScoreText();
    }

    // Method to increment the score
    public void IncrementScore()
    {
        score += 1;  // Increase score by 1 for each pin destroyed
        UpdateScoreText();  // Update the display with the score
    }

    // Method to update the score text on the screen
    private void UpdateScoreText()
    {
        if (scoreTMP != null)
        {
            scoreTMP.text = "  " + score.ToString();
        }
    }
}
