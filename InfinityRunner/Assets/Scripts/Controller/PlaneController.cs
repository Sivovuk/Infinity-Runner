using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// A simple script that is activated when something is placed on that part of the ground by which the player moves can be a gold or an obstacle (in order not to overlap)

//Prosta skripta koja se aktivira kada se nešto postavi na taj deo tla po kome se kreće igrač to može biti zlato ili prepreka(da se ne bi prekplapali)

public class PlaneController : MonoBehaviour {

    public bool tracker = false;

    void OnTriggerStay(Collider other){
        if (other.gameObject.tag.Equals("Obstical")) {
            tracker = true;
        }

        if (other.gameObject.tag.Equals("Gold")){
            tracker = true;
        }
    }
}
