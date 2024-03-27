using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneController : MonoBehaviour
{
    public Animator introAnimator; // Animator for the Intro01 animation
    public Camera mainCamera; // Main camera
    public PlayerController playerController; // PlayerController
    public Canvas timerCanvas; // TimerCanvas

    private bool animationFinished = false;

    void Start()
    {
        // Invoke the StartAfterDelay method after 2 seconds
        Invoke("StartAfterDelay", 4f);
    }

    void StartAfterDelay()
    {
        // Enable Main Camera
        mainCamera.gameObject.SetActive(true);

        // Enable PlayerController
        playerController.enabled = true;

        // Enable TimerCanvas
        timerCanvas.gameObject.SetActive(true);

        // Disable CutsceneController
        gameObject.SetActive(false);
    }

    // Method called when the Intro01 animation is finished playing
    public void OnIntro01AnimationFinished()
    {
        animationFinished = true;
    }
}
