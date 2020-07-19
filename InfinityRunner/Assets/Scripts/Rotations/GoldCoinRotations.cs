using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// A script used to rotate gold coins

//Skripta koja služi  za rotaciju zlatnika

public class GoldCoinRotations : MonoBehaviour {

    public float speed = 100;
    
    
	void Update () {
        transform.Rotate(Vector3.up * Time.deltaTime * speed);
        
    }
    
}
