using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//A short script to adjust the volume of music using the slider

//Kratka skripta za podešavanje jačine muzike pomoću slajdera

public class MusicValue : MonoBehaviour {

    public AudioSource music;
    public Slider slider;

    void Start()
    {
        slider.value = PlayerPrefMenager.GetMasterVolume();
    }

    void Update () {
        music.volume  = slider.value ;
        PlayerPrefMenager.SetMasterVolume(slider.value);
        slider.value = PlayerPrefMenager.GetMasterVolume();
    }
}
