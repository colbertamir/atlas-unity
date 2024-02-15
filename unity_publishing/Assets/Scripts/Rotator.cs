using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		// Rotate the coin around the x-axis 45 degrees per second
        transform.Rotate(Vector3.right * 45 * Time.deltaTime);
	}
}
