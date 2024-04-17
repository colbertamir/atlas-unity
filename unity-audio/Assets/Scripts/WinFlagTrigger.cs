using UnityEngine;

public class WinFlagTrigger : MonoBehaviour
{
    // Reference to the AudioClip for the victory sting
    public AudioClip victoryPianoClip;

    // Boolean flag to track whether the victory sting has been played
    private bool victoryStingPlayed = false;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider that entered the trigger has the "Player" tag
        if (other.CompareTag("Player"))
        {
            // If the victory sting has already been played, do nothing
            if (victoryStingPlayed)
            {
                return;
            }
            
            // Find the "Wallpaper" GameObject in the scene
            GameObject wallpaperObject = GameObject.Find("Wallpaper");
            if (wallpaperObject != null)
            {
                // Get the AudioSource component from the Wallpaper GameObject
                AudioSource audioSource = wallpaperObject.GetComponent<AudioSource>();
                if (audioSource != null)
                {
                    // Stop the background music
                    audioSource.Stop();

                    // Play the victory piano clip once using PlayOneShot
                    audioSource.PlayOneShot(victoryPianoClip);

                    // Set the victory sting flag to true to prevent it from playing again
                    victoryStingPlayed = true;
                }
            }
        }
    }
}
