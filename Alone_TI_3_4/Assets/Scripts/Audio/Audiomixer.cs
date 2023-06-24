using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Audiomixer : MonoBehaviour
{
    public AudioMixer mixer;
    public Slider generalVol;
    public Slider fxVol;
    public Slider musicVol;
    public Slider ambientVol;

    public void GeneralVolChange()
    {
        mixer.SetFloat("MasterVol", generalVol.value);
    }

    public void MusicVolChange()
    {
        mixer.SetFloat("MusicVol", musicVol.value);
    }

    public void FXVolChange()
    {
        mixer.SetFloat("FXVol", fxVol.value);
    }

    public void AmbientVolChange()
    {
        mixer.SetFloat("AmbientVol", ambientVol.value);
    }
}

