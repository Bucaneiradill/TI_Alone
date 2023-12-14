using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeScaleSet : MonoBehaviour
{
    float saveTimeScale;
    void OnEnable()
    {
        saveTimeScale = Time.timeScale;
        GameManager.instance.gmTimeScaleOff();
    }
   
    void OnDisable()
    {
        GameManager.instance.gmTimeScaleOn();
        Time.timeScale = saveTimeScale;
    }
}
