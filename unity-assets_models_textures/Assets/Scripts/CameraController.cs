using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target; // Reference to the player's transform
    public float distance = 5f; // Distance between the camera and the player
    public float height = 2f; // Height offset of the camera from the player
    public float sensitivity = 2f; // Sensitivity of the camera rotation

    private Vector2 cursorMovement;
    private Vector3 offset;

    void Start()
    {
        offset = new Vector3(0f, height, -distance); // Set the initial camera offset
    }

    void LateUpdate() // LateUpdate to ensure the player's movement has been processed
    {
        // Calculate the desired position of the camera
        Vector3 desiredPosition = target.position + offset;
        transform.position = desiredPosition;

        // Update camera rotation based on cursor input
        cursorMovement += new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y")) * sensitivity;
        cursorMovement.y = Mathf.Clamp(cursorMovement.y, -90f, 90f); // Clamp vertical rotation

        // Rotate the camera around the player based on cursor input
        transform.rotation = Quaternion.Euler(-cursorMovement.y, cursorMovement.x, 0f);
    }
}
