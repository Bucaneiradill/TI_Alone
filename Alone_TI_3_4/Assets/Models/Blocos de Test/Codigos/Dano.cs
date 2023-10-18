using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dano : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player")){
           Debug.Log("Dano");
           GameManager.instance.damage(10);
        }
    }
}
