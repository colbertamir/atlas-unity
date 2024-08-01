using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.UI;
using System.Collections.Generic;

public class ARObjectPlacer : MonoBehaviour
{
    public GameObject gamePrefab; // Reference to the game prefab
    public GameObject target1Prefab; // Reference to the Target1 prefab
    public GameObject target2Prefab; // Reference to the Target2 prefab
    public GameObject target3Prefab; // Reference to the Target3 prefab
    public GameObject target4Prefab; // Reference to the Target4 prefab
    public GameObject target5Prefab; // Reference to the Target5 prefab
    public GameObject slingshotPrefab; // Reference to the Slingshot prefab
    public GameObject startButtonPrefab; // Reference to the Start button prefab
    private GameObject instantiatedGamePrefab;
    private GameObject instantiatedStartButton;
    private ARRaycastManager raycastManager;
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();

    void Start()
    {
        raycastManager = GetComponent<ARRaycastManager>();
    }

    void Update()
    {
        // This script should only be active when we want to place stuff
    }

    public void PlaceObjectOnPlane(ARPlane plane)
    {
        if (gamePrefab != null && plane != null)
        {
            Vector3 position = plane.center; // Adjust as needed to place the prefab at the desired position
            instantiatedGamePrefab = Instantiate(gamePrefab, position, Quaternion.identity);
            Debug.Log("Game prefab placed on plane");

            // Activate the Canvas within the instantiated gamePrefab
            Transform canvasTransform = instantiatedGamePrefab.transform.Find("Canvas");
            if (canvasTransform != null)
            {
                canvasTransform.gameObject.SetActive(true);
                Debug.Log("Canvas activated");

                // Instantiate and set up the Start button
                if (startButtonPrefab != null)
                {
                    instantiatedStartButton = Instantiate(startButtonPrefab, canvasTransform);
                    Button startButton = instantiatedStartButton.GetComponent<Button>();
                    if (startButton != null)
                    {
                        startButton.onClick.AddListener(OnStartButtonClicked);
                        Debug.Log("Start button instantiated and listener added");
                    }
                    else
                    {
                        Debug.LogError("Start button component not found in prefab");
                    }
                }
                else
                {
                    Debug.LogError("Start button prefab is null");
                }
            }
            else
            {
                Debug.LogError("Canvas not found in instantiated Game prefab");
            }
        }
        else
        {
            Debug.LogError("Game prefab or selected plane is null");
        }
    }

    private void OnStartButtonClicked()
    {
        // Instantiate the target prefabs and slingshotPrefab when the Start button is clicked
        if (target1Prefab != null && target2Prefab != null && target3Prefab != null && target4Prefab != null && target5Prefab != null && slingshotPrefab != null && instantiatedGamePrefab != null)
        {
            Vector3 position = instantiatedGamePrefab.transform.position + new Vector3(0, 0.5f, 0); // Adjust position as needed
            Instantiate(target1Prefab, position + new Vector3(0, 0, 0), Quaternion.identity);
            Instantiate(target2Prefab, position + new Vector3(0.5f, 0, 0), Quaternion.identity);
            Instantiate(target3Prefab, position + new Vector3(1.0f, 0, 0), Quaternion.identity);
            Instantiate(target4Prefab, position + new Vector3(1.5f, 0, 0), Quaternion.identity);
            Instantiate(target5Prefab, position + new Vector3(2.0f, 0, 0), Quaternion.identity);
            Debug.Log("Target prefabs instantiated");

            Vector3 slingshotPosition = instantiatedGamePrefab.transform.position + new Vector3(0, 0, -1.0f); // Adjust position as needed
            Instantiate(slingshotPrefab, slingshotPosition, Quaternion.identity);
            Debug.Log("Slingshot prefab instantiated");

            // Disable the Start button
            if (instantiatedStartButton != null)
            {
                instantiatedStartButton.GetComponent<Button>().interactable = false;
                instantiatedStartButton.SetActive(false);
                Debug.Log("Start button disabled and hidden");
            }
        }
        else
        {
            Debug.LogError("One or more target prefabs, Slingshot prefab, or instantiated Game prefab is null");
        }
    }
}
