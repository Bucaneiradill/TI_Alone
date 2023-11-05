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

    private void Start()
    {
        FindOutline();
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
            player.gameObject.GetComponent<PlayerActions>().anim.SetTrigger("Collect");
            uiManager.DisplayAction($"Coletou {amount} {item.name}");
            //Destroy(gameObject);

            GameObject obj;
            obj = transform.GetChild(0).gameObject;
            obj.SetActive(false);
            //time = Time.time + delay;
           gameObject.GetComponent<SpawnerItem>().time = Time.time + gameObject.GetComponent<SpawnerItem>().delay;
        }
        else
        {
            uiManager.DisplayAction("Inventário cheio");
        }
    }
}
