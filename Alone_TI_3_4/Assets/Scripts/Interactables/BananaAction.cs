using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananaAction : Interactable
{

    [SerializeField] Item item;
    public int amount = 1;

    private void Start(){
        FindOutline();
    }

    /*------------------------------------------------------------------------------
    Função:     BaseAction
    Descrição:  
    Entrada:    -
    Saída:      -
    ------------------------------------------------------------------------------*/
   public override void BaseAction(){
        bool spaceInventory = Inventory.instance.CheckAndAddItem(item);
        if (spaceInventory == true){
            playerActions.Collect();
            ObjectPickUp();
        }
        else{
            UIManager.instance.DisplayAction("Inventário cheio");
        }
    }
    /*------------------------------------------------------------------------------
    Função:     SecundaryAction
    Descrição:  
    Entrada:    -
    Saída:      -
    ------------------------------------------------------------------------------*/
    public override void SecundaryAction(){
        playerActions.Collect(); 
        ObjectPickUp();
        Food();
    }
    /*------------------------------------------------------------------------------
    Função:     ObjectPickUp
    Descrição:  
    Entrada:    -
    Saída:      -
    ------------------------------------------------------------------------------*/
    public void ObjectPickUp(){
        UIManager.instance.DisplayAction($"Coletou {amount} {item.name}");
        Destroy(gameObject);
    }

    public void Food(){
        GameManager.instance.toEat(10);
        GameManager.instance.toDrink(10);  
    }
}
