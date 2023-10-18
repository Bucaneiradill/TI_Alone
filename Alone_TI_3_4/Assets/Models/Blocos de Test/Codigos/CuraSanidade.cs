using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuraSanidade : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player")){
           Debug.Log("Sao");
           GameManager.instance.toSane(10);
        }
    }
}
