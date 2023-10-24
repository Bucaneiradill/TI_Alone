using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeScaleSet : MonoBehaviour
{
    void OnEnable()
    {
        GameManager.instance.gmTimeScaleOff();
    }
   
    void OnDisable()
    {
        GameManager.instance.gmTimeScaleOn();
    }
}
