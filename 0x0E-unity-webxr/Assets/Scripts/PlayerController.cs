using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float sensitivity = 100f;  // Mouse sensitivity for camera movement
    public float moveSpeed = 5f;      // Movement speed for WASD/arrow keys
    private float mouseX, mouseY;
    private float rotationX = 0f;     // Track camera's X-axis rotation (pitch)

    void Start()
    {
        // Lock the cursor to the game window and hide it
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        // Handle camera movement with WASD or arrow keys
        float moveX = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float moveZ = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        transform.Translate(new Vector3(moveX, 0, moveZ));

        // Get mouse input for rotating the camera
        mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        // Rotate the camera around the Y-axis (left and right movement)
        transform.Rotate(Vector3.up * mouseX);

        // Adjust the camera pitch (up and down rotation) while clamping it to avoid over-rotation
        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f); // Clamp rotation to prevent flipping

        // Apply the rotation to the camera
        transform.localRotation = Quaternion.Euler(rotationX, transform.eulerAngles.y, 0);
    }
}
