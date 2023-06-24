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

    private void OnEnable()
    {
        float masterValue;
        if (mixer.GetFloat("MasterVol", out masterValue))
        {
            generalVol.value = masterValue;
        }

        float musicValue;
        if (mixer.GetFloat("MusicVol", out musicValue))
        {
            musicVol.value = musicValue;
        }

        float fxValue;
        if (mixer.GetFloat("FXVol", out fxValue))
        {
            fxVol.value = fxValue;
        }

        float ambientValue;
        if (mixer.GetFloat("AmbientVol", out ambientValue))
        {
            ambientVol.value = ambientValue;
        }
    }

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

