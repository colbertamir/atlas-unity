using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class PlayerController : MonoBehaviour
{
    public float speed = 10f; // Increase the speed for faster movement
    public float rotationSpeed = 90f; // Rotation speed for diagonal movement
    public float gravity = -20f;
    public float jumpSpeed = 15f; // Jump speed

    public Transform startPosition; // Start position of the player

    CharacterController characterController;
    Vector3 moveVelocity;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Check for input and move the player accordingly
        float moveHorizontal = Input.GetAxis("Horizontal"); // Gets input from A/D or left/right arrow keys
        float moveVertical = Input.GetAxis("Vertical"); // Gets input from W/S or up/down arrow keys

        // Calculates the movement based on the input
        Vector3 move = new Vector3(moveHorizontal, 0, moveVertical);

        // Jump function
        if (characterController.isGrounded && Input.GetButtonDown("Jump")) // Check if the player is grounded and jump button is pressed
        {
            moveVelocity.y = jumpSpeed; // Apply jump velocity directly to moveVelocity.y
        }

        // Apply gravity
        moveVelocity.y += gravity * Time.deltaTime;

        // Move the player horizontally using CharacterController
        characterController.Move(move * speed * Time.deltaTime);

        // Move the player vertically using CharacterController
        characterController.Move(moveVelocity * Time.deltaTime);

        // Check if the player has fallen off the platform
        if (transform.position.y < -30f) // Adjust the value as needed
        {
            // Reset player position to the start position
            transform.position = startPosition.position;
            // Reset player velocity
            moveVelocity = Vector3.zero;
        }
    }
}
