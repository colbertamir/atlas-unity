using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Method to load the selected level scene
    public void LevelSelect(int level)
    {
        // Check which level button was clicked and load the corresponding scene
        switch (level)
        {
            case 1:
                SceneManager.LoadScene("Level01"); // Load Level01
                break;
            case 2:
                SceneManager.LoadScene("Level02"); // Load Level02
                break;
            case 3:
                SceneManager.LoadScene("Level03"); // Load Level03
                break;
            default:
                Debug.LogError("Invalid level selection!"); // Log error if an invalid level is selected
                break;
        }
    }

    // Method to load the Options scene
    public void Options()
    {
        SceneManager.LoadScene("Options"); // Load Options
    }

    // Method to exit the game
    public void ExitGame()
    {
        Debug.Log("Exited"); // Logs "Exited" to Console
        Application.Quit(); // Quits game
    }
}
