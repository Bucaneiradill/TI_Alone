using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerItem : MonoBehaviour
{
    public float time;
    public GameObject obj;
    public float delay;
    
    void Start(){
        obj = transform.GetChild(0).gameObject;
    }

    public void Active(){
        obj.SetActive(true);
    }
    void OnDisable(){
        time = Time.time + delay;
        Debug.Log(time);
    }
    
}
