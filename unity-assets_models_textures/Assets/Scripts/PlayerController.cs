using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    public float rotationSpeed = 90f; // Rotation speed for diagonal movement
    public float gravity = -20f;
    public float jumpSpeed = 1f; // Jump speed

    CharacterController characterController;
    Vector3 moveVelocity;

    void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Check for input and move the player accordingly
        float moveHorizontal = Input.GetAxis("Horizontal"); // Gets input from A/D or left/right arrow keys
        float moveVertical = Input.GetAxis("Vertical"); // Gets input from W/S or up/down arrow keys

        // Calculates the movement based on the input
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        movement = movement.normalized * speed * Time.deltaTime;

        // Rotate the movement vector according to the camera's forward direction
        movement = Quaternion.AngleAxis(Camera.main.transform.eulerAngles.y, Vector3.up) * movement;

        // Check if the player is grounded and the Space button is pressed
        if (characterController.isGrounded && Input.GetButtonDown("Jump"))
        {
            // Apply an upward velocity for jumping
            moveVelocity.y = jumpSpeed;
        }

        // Combine movement with jump velocity
        moveVelocity = new Vector3(movement.x, moveVelocity.y, movement.z);

        // Apply gravity
        moveVelocity.y += gravity * Time.deltaTime;

        // Move the player using CharacterController
        characterController.Move(moveVelocity);
    }
}
