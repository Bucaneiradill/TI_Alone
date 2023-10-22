using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fome : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player")){
           Debug.Log("Fome");
           GameManager.instance.toHungry(10);
        }
    }
}
