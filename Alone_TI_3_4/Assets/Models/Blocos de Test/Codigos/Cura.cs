using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cura : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player")){
           Debug.Log("Cura");
           GameManager.instance.recover(10);
        }
    }
}
