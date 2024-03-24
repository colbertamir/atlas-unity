using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseCanvas; // Reference to the PauseCanvas GameObject

    // Method to pause the game
    public void Pause()
    {
        Time.timeScale = 0; // Pause the game
        pauseCanvas.SetActive(true); // Activate the PauseCanvas
    }

    // Method to resume the game
    public void Resume()
    {
        Time.timeScale = 1; // Resume the game
        pauseCanvas.SetActive(false); // Deactivate the PauseCanvas
    }

    // Method to restart the level
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload the current scene
    }

    // Method for MainMenu
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu"); // Load MainMenu
    }

    // Method to load Options
    public void Options()
    {
        SceneManager.LoadScene("Options"); // Load Options
    }
    // Update is called once per frame
    void Update()
    {
        // Check if the player presses the Escape key
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 0)
            {
                Resume(); // If game is paused, resume it
            }
            else
            {
                Pause(); // If game is not paused, pause it
            }
        }
    }
}
