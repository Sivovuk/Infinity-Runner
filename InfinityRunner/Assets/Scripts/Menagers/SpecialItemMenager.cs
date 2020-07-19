using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// The script installs a boost in a certain position and activates it, it all happens when a player passes through a colander

//Skripta namešta boost na određenoj poziciji i aktivira ga, sve to dešava kada igrač prođe kroz colajder

public class SpecialItemMenager : MonoBehaviour {

    public GameObject item;
    public GameObject plane;

    static int tracker;

    void Start () {
        
    }

    void OnTriggerEnter(Collider other){
        if (other.name.Equals("Ball")) {
            if (tracker >= 5) {
                item.transform.position = new Vector3(plane.transform.position.x, 0, plane.transform.position.z);
                item.SetActive(true);
                tracker = 0;
            } else if (tracker < 5) {
                tracker++;
            }
        }
    }
}
