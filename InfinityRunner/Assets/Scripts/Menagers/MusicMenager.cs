using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script that calls specific music or sound

//Skripta koja poziva odredjenu muziku ili zvuk

public class MusicMenager : MonoBehaviour {

    public AudioSource menuMusic;
    public AudioSource goldCollecting;

    // The method of sound is the sound for collecting gold when called

    //Metoda aktiva zvuk za skupljanje zlata kada se pozove
    public void GoldCoinCollecting() {
        goldCollecting.Play();
    }
    

}
