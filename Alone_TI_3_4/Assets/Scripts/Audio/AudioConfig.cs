using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioConfig : MonoBehaviour
{

    public AudioSource musica;
    public Slider sliderVolume;

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

     public void Volume()
    {
        musica.volume = sliderVolume.value;
    }

}

