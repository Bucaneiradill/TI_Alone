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

    [SerializeField] Item item; 
    
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
        
        bool spaceInventory = Inventory.instance.AddItem(item, 1);
        if(spaceInventory == true){
            Destroy(gameObject);
        }
    }
}
