using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// A boost-related script that increases player speed to max

//Skripta koja je povezana sa boost-om koji povećava brzinu igrača na max

public class SpecialItem : MonoBehaviour {

    public GameObject player;
    
	void Start () {
		
	}
	
	void Update () {
		
	}

    void OnTriggerEnter(Collider other){
        if (other.tag.Equals("Player")) {
            player.GetComponent<PlayerMove>().moveSpeed = 30;
            gameObject.SetActive(false);
        }
    }
}
