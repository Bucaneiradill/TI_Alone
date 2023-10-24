using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Comer : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player")){
           Debug.Log("Comer");
           GameManager.instance.toEat(10);
        }
    }
}
