using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//A short script for adjusting the game sounds using the slider

public class SoundValue : MonoBehaviour {

    public AudioSource sounds;
    public Slider slider;

    void Start(){
        slider.value = PlayerPrefMenager.GetSounds();
    }

    void Update()
    {
        sounds.volume = slider.value;
        PlayerPrefMenager.SetSounds(sounds.volume);
        
    }
}
