using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.UI;
using System.Collections.Generic;  // Add this line

public class PlaneSelector : MonoBehaviour
{
    public ARPlaneManager arPlaneManager;
    public GameObject startButtonPrefab;

    private static ARPlane selectedPlane;

    void Start()
    {
        arPlaneManager.planesChanged += OnPlanesChanged;
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                var touchPosition = touch.position;
                if (TryGetTouchedPlane(touchPosition, out ARPlane plane))
                {
                    SelectPlane(plane);
                }
            }
        }
    }

    private bool TryGetTouchedPlane(Vector2 touchPosition, out ARPlane plane)
    {
        var raycastHits = new List<ARRaycastHit>();
        if (arPlaneManager.Raycast(touchPosition, raycastHits, TrackableType.PlaneWithinPolygon))
        {
            var hit = raycastHits[0];
            plane = arPlaneManager.GetPlane(hit.trackableId);
            return true;
        }

        plane = null;
        return false;
    }

    private void SelectPlane(ARPlane plane)
    {
        if (selectedPlane == null)
        {
            selectedPlane = plane;
            arPlaneManager.planesChanged -= OnPlanesChanged;
            foreach (var p in arPlaneManager.trackables)
            {
                if (p != plane)
                {
                    p.gameObject.SetActive(false);
                }
            }

            DisplayStartButton();
        }
    }

    private void OnPlanesChanged(ARPlanesChangedEventArgs args)
    {
        if (selectedPlane != null)
        {
            foreach (var plane in args.added)
            {
                plane.gameObject.SetActive(false);
            }
        }
    }

    private void DisplayStartButton()
    {
        var startButton = Instantiate(startButtonPrefab, new Vector3(Screen.width / 2, Screen.height / 2, 0), Quaternion.identity);
        startButton.transform.SetParent(GameObject.Find("Canvas").transform, false);
    }
}
