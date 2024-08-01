using UnityEngine;

public class SlingshotController : MonoBehaviour
{
    public GameObject slingshotPrefab; // Reference to the slingshot prefab
    private GameObject currentSlingshot;
    private Vector3 initialPosition;
    private Vector3 dragStartPos;
    private bool isDragging = false;
    private bool isSlingshotLoaded = false;
    private float launchForceMultiplier = 500f;

    void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, Camera.main.nearClipPlane));

            if (touch.phase == TouchPhase.Began && Vector3.Distance(touchPosition, initialPosition) < 0.5f && !isSlingshotLoaded)
            {
                currentSlingshot = Instantiate(slingshotPrefab, initialPosition, Quaternion.identity);
                isDragging = true;
                isSlingshotLoaded = true;
                dragStartPos = touchPosition;
            }
            else if (touch.phase == TouchPhase.Moved && isDragging)
            {
                Vector3 dragPosition = new Vector3(touchPosition.x, touchPosition.y, initialPosition.z);
                currentSlingshot.transform.position = dragPosition;
            }
            else if (touch.phase == TouchPhase.Ended && isDragging)
            {
                Vector3 launchDirection = dragStartPos - touchPosition;
                currentSlingshot.GetComponent<Rigidbody>().AddForce(launchDirection * launchForceMultiplier);
                isDragging = false;
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Target")
        {
            Destroy(currentSlingshot);
            isSlingshotLoaded = false;
        }
        else if (currentSlingshot.transform.position.y < -5f)
        {
            Destroy(currentSlingshot);
            isSlingshotLoaded = false;
        }
    }
}
