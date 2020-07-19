using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// The script serves to turn on or off the sound associated with the checkbox, depending on whether the checkbox is active or not

//Skripta služi da uključi ili isključi zvuk koji je povezan sa checkbox-om, u zavisnosti ako je checkbox aktivan ili ne

public class TurnOffSounds : MonoBehaviour {

    public Toggle checkbox;
    public AudioSource sound;

    void Update(){
        if (checkbox.isOn){
            sound.enabled = true;
        }
        else {
            sound.enabled = false;
        }
    }
}
