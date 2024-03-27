using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    public float speed = 10f; // Increase the speed for faster movement
    public float rotationSpeed = 90f; // Rotation speed for diagonal movement
    public float gravity = -20f;
    public float jumpSpeed = 15f; // Jump speed

    public Transform startPosition; // Start position of the player
    public Animator animator; // Reference to the Animator component

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

        // Calculate player's movement direction
        Vector3 moveDirection = new Vector3(moveHorizontal, 0f, moveVertical).normalized;

        // Jump function
        bool grounded = characterController.isGrounded;
        Debug.Log("Grounded: " + grounded);
        if (grounded)
        {
            // Calculate player's movement speed
            float currentSpeed = moveDirection.magnitude * speed;

            // Apply movement
            characterController.Move(moveDirection * currentSpeed * Time.deltaTime);

            // Update animator parameter
            animator.SetFloat("Speed", currentSpeed);

            // Check if the character is grounded and the jump velocity is downward
            if (moveVelocity.y < 0f)
            {
                moveVelocity.y = 0f; // Reset the vertical velocity
            }

            // Check for jump input
            if (Input.GetButtonDown("Jump"))
            {
                moveVelocity.y = jumpSpeed; // Apply jump velocity
            }
        }

        // Apply gravity
        moveVelocity.y += gravity * Time.deltaTime;

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
