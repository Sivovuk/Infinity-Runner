using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefMenager : MonoBehaviour {

    const string MASTER_VOLUME_KEY = "master_volume";
    const string SOUNDS_KEY = "sounds";


    public static void SetMasterVolume(float volume) {
        if (volume >= 0f && volume <= 1f)
        {
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
        }
        else
        {
            Debug.LogError("Master volume out of range!");
        }
    }

    public static float GetMasterVolume()
    {
        return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
    }

    public static void SetSounds(float volume) {
        if (volume >= 0f && volume <= 1f)
        {
            PlayerPrefs.SetFloat(SOUNDS_KEY, volume);
        }
        else
        {
            Debug.LogError("Master volume out of range!");
        }
    }

    public static float GetSounds() {
        return PlayerPrefs.GetFloat(SOUNDS_KEY);
    }
}
