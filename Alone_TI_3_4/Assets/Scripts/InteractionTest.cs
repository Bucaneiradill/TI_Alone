using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionTest : Interactable
{
    UIManager uiManager;
    //void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("Player")){
    //        Destroy(gameObject);
    //        GameManager.instance.Beber(10);
    //        GameManager.instance.Comer(10);
    //        Debug.Log("Comeu e Bebeu");
    //    }
    //}

    private void Start()
    {
        uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }

    public override void Interact()
    {
        base.Interact();
        GameManager.instance.Beber(10);
        GameManager.instance.Comer(10);
        Debug.Log("Comeu e Bebeu");
        uiManager.DisplayAction($"Comida e água +10");
        Destroy(gameObject);
    }
}
