using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectScene : MonoBehaviour
{
    public void ChangeScene(int scene)
    {
        GetComponent<AudioSource>().Play();
        SceneManager.LoadScene(scene);
    }
}
