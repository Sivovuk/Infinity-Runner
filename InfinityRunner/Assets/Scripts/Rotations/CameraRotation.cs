using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script used to rotate the camera

//Skripta koja služi za rotaciju kamere

public class CameraRotation : MonoBehaviour {

    public float speed;
	
	void Update () {
        transform.Rotate(Vector3.up * Time.deltaTime * speed);
	}
}
