using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerSanidade : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player")){
           Debug.Log("Insano");
           GameManager.instance.toInsane(10);
        }
    }
}
