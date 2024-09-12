using UnityEngine;

public class BowlingPins : MonoBehaviour
{
    private ScoreManager scoreManager; // Reference to ScoreManager 

    void Start()
    {
        // Find the ScoreManager in the scene and store the reference
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if ball has collided with a pin
        if (collision.gameObject.CompareTag("Ball"))
        {
            // Tell the ScoreManager to update the score
            if (scoreManager != null)
            {
                scoreManager.IncrementScore();
            }
            // Destroy the pin
            Destroy(gameObject);
        }
    }
}
