using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// A script that, when activated, calls the method that moves platforms that remain behind the player

//Skripta koja kad se aktivira poziva metoda koja pomera platforme koje ostaju iza igrača

public class PlatformMenager : MonoBehaviour {

    public GameObject levelMenager;

    void OnTriggerEnter(Collider other){

        if (other.tag.Equals("Player")) {
            levelMenager.GetComponent<LevelMenager>().PlatformControler(gameObject);
        }
    }

    
}
