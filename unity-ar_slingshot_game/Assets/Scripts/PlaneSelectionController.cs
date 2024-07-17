using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using System.Collections.Generic;

[RequireComponent(typeof(ARRaycastManager))]
public class PlaneSelectionController : MonoBehaviour
{
    [Header("AR Components")]
    public ARPlaneManager planeManager; // Reference to the ARPlaneManager
    public ARRaycastManager raycastManager; // Reference to the ARRaycastManager
    public Camera arCamera; // Reference to the AR Camera

    [Header("Controller Reference")]
    public PlanePlacementController placementController; // Reference to the PlanePlacementController

    private ARPlane selectedPlane; // Store the currently selected AR plane

    void Update()
    {
        // Perform a raycast to detect if a plane is tapped
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Debug.Log("Screen tapped");
            Touch touch = Input.GetTouch(0);
            Vector2 touchPosition = touch.position;

            // Perform the raycast
            List<ARRaycastHit> hits = new List<ARRaycastHit>();
            if (raycastManager.Raycast(touchPosition, hits, TrackableType.PlaneWithinPolygon))
            {
                Debug.Log("Raycast hit something");
                ARPlane hitPlane = planeManager.GetPlane(hits[0].trackableId);
                if (hitPlane != null)
                {
                    Debug.Log("Raycast hit a plane");
                    SelectPlane(hitPlane);
                }
                else
                {
                    Debug.Log("Raycast hit: " + hits[0].trackableId);
                }
            }
            else
            {
                Debug.Log("Raycast did not hit any plane");
            }
        }
    }

    void SelectPlane(ARPlane plane)
    {
        if (selectedPlane != null)
        {
            selectedPlane.gameObject.SetActive(true);
        }

        // Disable all other planes
        foreach (var otherPlane in planeManager.trackables)
        {
            if (otherPlane != plane)
            {
                otherPlane.gameObject.SetActive(false);
            }
        }

        // Set the selected plane
        selectedPlane = plane;
        selectedPlane.gameObject.SetActive(true); // Ensure the selected plane is active

        // Start the PlanePlacementController and place the Game prefab
        if (placementController != null)
        {
            placementController.enabled = true;
            placementController.PlaceGameOnPlane(selectedPlane);
            Debug.Log("PlanePlacementController enabled and Game placed on plane");
        }

        // Disable the ARPlaneManager and this PlaneSelectionController script
        planeManager.enabled = false;
        Debug.Log("ARPlaneManager is disabled");
    }
}
