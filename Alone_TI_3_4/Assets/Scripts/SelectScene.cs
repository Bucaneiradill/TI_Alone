using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectScene : MonoBehaviour
{
    [SerializeField] SceneFader fader;

    private void Start()
    {
        fader = FindObjectOfType<SceneFader>();
    }

    private void OnLevelWasLoaded()
    {
        fader = FindObjectOfType<SceneFader>();
    }

    public void ChangeScene(int scene)
    {
        fader.FadeTo(scene);
    }
}
