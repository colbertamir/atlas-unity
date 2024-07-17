using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.UI;

public class PlanePlacementController : MonoBehaviour
{
    public PlaneSelectionController planeSelectionController; // Reference to the PlaneSelectionController
    public GameObject gamePrefab; // Reference to the Game prefab
    public GameObject targetPrefab; // Reference to the Target prefab

    private GameObject instantiatedGamePrefab;

    void Start()
    {
        // PlaneSelectionController should not be disabled at the start
        if (planeSelectionController == null)
        {
            Debug.LogError("PlaneSelectionController reference is null");
        }
    }

    public void PlaceGameOnPlane(ARPlane plane)
    {
        // Instantiate the gamePrefab on the selected plane
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

                // Find the Start button and add a listener to it
                Button startButton = canvasTransform.GetComponentInChildren<Button>();
                if (startButton != null)
                {
                    startButton.onClick.AddListener(OnStartButtonClicked);
                    Debug.Log("Start button listener added");
                }
                else
                {
                    Debug.LogError("Start button not found in Canvas");
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
        // Instantiate the targetsPrefab when the Start button is clicked
        if (targetsPrefab != null && instantiatedGamePrefab != null)
        {
            Vector3 position = instantiatedGamePrefab.transform.position + new Vector3(0, 0.5f, 0);
            Instantiate(targetsPrefab, position, Quaternion.identity);
            Debug.Log("Targets prefab instantiated");

            // Disable the Start button
            Button startButton = instantiatedGamePrefab.GetComponentInChildren<Button>();
            if (startButton != null)
            {
                startButton.interactable = false;
                Debug.Log("Start button disabled");
            }
            else
            {
                Debug.LogError("Start button not found in instantiated Game prefab");
            }

            // Disable the PlaneSelectionController script
            if (planeSelectionController != null)
            {
                planeSelectionController.enabled = false;
                Debug.Log("PlaneSelectionController disabled after target prefab instantiated");
            }
        }
        else
        {
            Debug.LogError("Target prefab or instantiated Game prefab is null");
        }
    }
}
