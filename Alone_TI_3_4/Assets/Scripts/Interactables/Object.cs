/**************************************************************
    Jogos Digitais SG
    Object

    Descrição:  

    Alone - Jogos Digitais SG –  09/04/2022
    Modificado por: Italo 
***************************************************************/

//-------------------------- Bibliotecas Usadas --------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : Interactable
{
    UIManager uiManager;
    [SerializeField] Item item;
    [SerializeField] int amount = 1;
    [SerializeField] PlayerActions player;

    private void Start()
    {
        uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }

    /*------------------------------------------------------------------------------
    Função:     Interact
    Descrição:  
    Entrada:    -
    Saída:      -
    ------------------------------------------------------------------------------*/
    public override void Interact()
    {
        base.Interact();
        ObjectPickUp();
    }
    /*------------------------------------------------------------------------------
    Função:     ObjectPickUp
    Descrição:  
    Entrada:    -
    Saída:      -
    ------------------------------------------------------------------------------*/
    private void ObjectPickUp(){
        
        bool spaceInventory = Inventory.instance.CheckAndAddItem(item);
        if(spaceInventory == true){
            uiManager.DisplayAction($"Coletou {amount} {item.name}");
            player.anim.SetTrigger("Collect");
            Destroy(gameObject);
        }
        else
        {
            uiManager.DisplayAction("Inventário cheio");
        }
    }
}
