using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    public float moveSpeed;
    public bool activator = false;

    float timePass;

    // A player's move forward moves with, even after a certain time, the player's speed increases gradually, but stops when it reaches 30

    //Skripta za pomeranje igraca napred u pravcu z, takođe posle određenog vremena brzina igrača se postepeno povećava ali staje kada dodje do 30

    void Update () {
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);

        timePass += Time.deltaTime;
        if (timePass >= 10 && activator == false) {
            moveSpeed += 5;
            timePass = 0;
            if (moveSpeed >= 30) {
                activator = true;
            }
        }
    }
    
    
}
