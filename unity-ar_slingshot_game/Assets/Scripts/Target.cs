using UnityEngine;
using UnityEngine.XR.ARFoundation; // Add this to use ARPlane

public class Target : MonoBehaviour
{
    private Vector3 direction;
    private float speed = 0.5f; // Adjust speed
    private ARPlane plane;

    public void Initialize(ARPlane plane)
    {
        this.plane = plane;
        direction = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)).normalized;
    }

    void Update()
    {
        if (plane == null) return;

        // Move the target in the direction
        transform.Translate(direction * speed * Time.deltaTime, Space.World);

        // Check bounds and reverse direction if needed
        Vector3 localPosition = plane.transform.InverseTransformPoint(transform.position);
        Vector2 planeSize = plane.size * 0.5f;
        if (Mathf.Abs(localPosition.x) > planeSize.x || Mathf.Abs(localPosition.z) > planeSize.y)
        {
            direction = -direction;
        }
    }
}
