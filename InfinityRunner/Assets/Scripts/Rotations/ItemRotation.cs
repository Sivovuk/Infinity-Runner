using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script used to rotate boost item

//Skripta koja služi za rotaciju boost-a

public class ItemRotation : MonoBehaviour {

	
	void Update () {
        transform.Rotate((Vector3.up + Vector3.right) * Time.deltaTime * 300f);
    }
}
