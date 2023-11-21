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
    public int amount = 1;

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

    public override void BaseAction()
    {
        base.BaseAction();
        bool spaceInventory = Inventory.instance.CheckAndAddItem(item);
        if (spaceInventory == true)
        {
            player.gameObject.GetComponent<PlayerActions>().anim.SetTrigger("Collect");
            for(int i = 0; i < amount - 1; i++)
            {
                Debug.Log("Inventario");
                Inventory.instance.CheckAndAddItem(item);
            }
        }
        else
        {
            uiManager.DisplayAction("Inventário cheio");
        }
    }
    /*------------------------------------------------------------------------------
    Função:     ObjectPickUp
    Descrição:  
    Entrada:    -
    Saída:      -
    ------------------------------------------------------------------------------*/
    public override void ObjectPickUp()
    {
        uiManager.DisplayAction($"Coletou {amount} {item.name}");
        Destroy(gameObject);
    }
}
