using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionTest : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")){
            Destroy(gameObject);
            GameManager.instance.Beber(10);
            GameManager.instance.Comer(10);
            Debug.Log("Comeu e Bebeu");
        }
    }
}
