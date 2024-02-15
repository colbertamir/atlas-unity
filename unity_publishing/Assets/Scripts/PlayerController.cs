using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour 
{
    public float speed = 10f;
    public int health = 5;
    public Text scoreText;
    public Text healthText;
    public Text winLoseText;
    public Image winLoseBG; 
    private Rigidbody rb;
    private int score = 0;

    void Start () 
    {
        rb = GetComponent<Rigidbody>();
        SetScoreText(); // Calls the SetScoreText method when the game starts
        SetHealthText(); // Calls the SetHealthText method when the game starts
        
        // Ensure that the winLoseText and winLoseBG are initially deactivated 
        
        winLoseText.gameObject.SetActive(false); 
        winLoseBG.gameObject.SetActive(false);
    }
    
    void FixedUpdate () 
    {
        // Check for input and move the player accordingly
        float moveHorizontal = Input.GetAxis("Horizontal"); // Gets input from A/D or left/right arrow keys
        float moveVertical = Input.GetAxis("Vertical"); // Gets input from W/S or up/down arrow keys

        // Calculates the movement based on the input
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        movement = movement.normalized * speed * Time.deltaTime;

        // Move the player using physics
        rb.MovePosition(transform.position + movement);
    }

    // Handles collisions
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pickup")) // Tag is "Pickup"
        {
            // Increment the score
            score++;

            // Update the score text
            SetScoreText();

            // Destroy the pickup object on contact
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Trap")) // Tag is "Trap"
        {
            // Decrement the health
            health--;

            // Update the health text
            SetHealthText();
        }
        else if (other.CompareTag("Goal")) // Tag "Goal"
        {
            // Display "You Win!" UI
            winLoseText.text = "You Win!";
            // Change the color of the win/lose text to black
            winLoseText.color = Color.black;
            // Change the color of background to green
            winLoseBG.color = Color.green;
            // Enable the UI elements
            winLoseText.gameObject.SetActive(true);
            winLoseBG.gameObject.SetActive(true);
            // Disable the collider of the Goal object to prevent triggering multiple times
            other.enabled = false;
            
            // Call LoadScene to restart the game after a delay
            StartCoroutine(LoadScene(3f));
        }

        // Check if health reaches 0
        if (health <= 0)
        {
            SetGameOver();
        }
    }

    // Method to update the score text
    void SetScoreText()
    {
        scoreText.text = "Score: " + score.ToString(); // Update the score text
    }

    // Method to update the health text
    void SetHealthText()
    {
        healthText.text = "Health: " + health.ToString(); // Update the health text
    }

    // Method to set the game over state
    void SetGameOver()
    {
        // Display "Game Over!" UI
        winLoseText.text = "Game Over!";
        // Changes the color of the win/lose text to white
        winLoseText.color = Color.white;
        // Changes the color of background to red
        winLoseBG.color = Color.red;
        // Enable the UI elements
        winLoseText.gameObject.SetActive(true);
        winLoseBG.gameObject.SetActive(true);
        // Restart the game after a little delay
        StartCoroutine(LoadScene(3f));
    }

    // Coroutine to reload the scene after 3 sec
    IEnumerator LoadScene(float seconds)
    {
        // Wait for the 3 secs
        yield return new WaitForSeconds(seconds);
        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void Update()
    {
        // Check if the player presses the Esc key
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Load the menu scene
            SceneManager.LoadScene("menu");
        }
    }
}
