using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource audioSourceMusicaDefundo;

    void Start()
    {
        GetComponent<AudioSource>().Play();
    }

   
}
