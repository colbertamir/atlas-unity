using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour 
{
    public GameObject player;
    private Vector3 offset;


    void Start () 
    {
        // Calculate the initial offset between camera and player
        offset = transform.position - player.transform.position;
    }
    
    void FixedUpdate () 
    {
        // Update the camera's position relative to player
        transform.position = player.transform.position + offset;
    }
}
