using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beber : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player")){
           Debug.Log("Beber");
           GameManager.instance.toDrink(10);
        }
    }
}
