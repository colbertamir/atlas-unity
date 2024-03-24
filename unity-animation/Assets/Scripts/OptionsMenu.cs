<<<<<<< HEAD
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour
{
    // Keep track of the previous scene index
    private int previousSceneIndex;

    // Called when the script instance is being loaded
    void Awake()
    {
        // Set the previous scene index to the current scene index
        previousSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    // Method to handle the back button functionality
    public void Back()
    {
        // Load the previous scene using the previous scene index
        SceneManager.LoadScene(previousSceneIndex);
    }
}
=======
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour
{
    // Keep track of the previous scene index
    private int previousSceneIndex;

    // Called when the script instance is being loaded
    void Awake()
    {
        // Set the previous scene index to the current scene index
        previousSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    // Method to handle the back button functionality
    public void Back()
    {
        // Load the previous scene using the previous scene index
        SceneManager.LoadScene(previousSceneIndex);
    }
}
>>>>>>> 1eed6a1f476dc9bbb52b675e027801dc5eef8052
