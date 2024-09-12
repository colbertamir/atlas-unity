using UnityEngine;

public class BallController : MonoBehaviour
{
    public float throwForce = 105f;      // Force applied when ball is thrown
    public float pickUpDistance = 5f;   // The maximum distance for picking up the ball
    public float controlForce = 10f;    // The force applied to move the ball left/right

    private Rigidbody rb;
    private Camera mainCamera;
    private bool isPickedUp = false;    // Ball is currently picked up
    private bool isReleased = false;    // Ball has been released
    private static BallController pickedUpBall = null; // Static reference to track picked up ball

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mainCamera = Camera.main;  // Gets the main camera reference
    }

    void Update()
    {
        // Handles pick up and release of the ball
        if (Input.GetMouseButtonDown(0))
        {
            if (isPickedUp)
            {
                ReleaseBall();
            }
            else
            {
                TryPickUpBall();
            }
        }

        // If the ball is picked up, move it with the mouse
        if (isPickedUp)
        {
            MoveBallWithMouse();
        }

        // If the ball is released, allow movement control with arrow keys
        if (isReleased)
        {
            ControlBallWithArrowKeys();
        }
    }

    private void TryPickUpBall()
    {
        // Performs a raycast to check if the mouse is pointing at this ball
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            // Check if the raycast hit this ball
            if (hit.transform == transform && !isPickedUp && pickedUpBall == null)
            {
                // Set this ball as picked up
                isPickedUp = true;
                isReleased = false; // Reset released state
                rb.useGravity = false;   // Disable gravity while holding the ball
                rb.velocity = Vector3.zero; // Stop any current movement
                rb.angularVelocity = Vector3.zero; // Stop any rotation

                // Set this ball as the currently picked up ball
                pickedUpBall = this;
            }
        }
    }

    private void MoveBallWithMouse()
    {
        // Move the ball based on the mouse position
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Vector3.Distance(mainCamera.transform.position, transform.position); // Distance from the camera
        Vector3 worldPos = mainCamera.ScreenToWorldPoint(mousePos);

        rb.MovePosition(worldPos); // Move the ball to the new position
    }

    private void ReleaseBall()
    {
        // Release the ball and apply a throw force
        isPickedUp = false;
        isReleased = true;  // Mark the ball as released
        rb.useGravity = true;

        // Calculate direction based on the camera's forward vector
        Vector3 throwDirection = mainCamera.transform.forward;

        // Apply a force to simulate rolling
        rb.AddForce(throwDirection * throwForce, ForceMode.Impulse);

        // Clear the reference to the currently picked up ball
        pickedUpBall = null;
    }

    private void ControlBallWithArrowKeys()
    {
        // Allow left/right movement using arrow keys after release
        float moveInput = Input.GetAxis("Horizontal"); // A/D or Left/Right Arrow keys

        // Apply force to move the ball left or right
        rb.AddForce(Vector3.right * moveInput * controlForce);
    }
}
