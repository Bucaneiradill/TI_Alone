using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoconutAction : Interactable
{
    UIManager uiManager;
    [SerializeField] Item item;
    //[SerializeField] Image icon1;
    //[SerializeField] Image icon2; 

    public int amount = 1;

    private void Start(){
        FindOutline();
        uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
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
            player.gameObject.GetComponent<PlayerActions>().anim.SetTrigger("Collect");
            ObjectPickUp();
        }
        else{
            uiManager.DisplayAction("Inventário cheio");
        }
    }
    /*------------------------------------------------------------------------------
    Função:     SecundaryAction
    Descrição:  
    Entrada:    -
    Saída:      -
    ------------------------------------------------------------------------------*/
    public override void SecundaryAction(){ 
        Food();
    }
    /*------------------------------------------------------------------------------
    Função:     ObjectPickUp
    Descrição:  
    Entrada:    -
    Saída:      -
    ------------------------------------------------------------------------------*/
    public void ObjectPickUp(){
        uiManager.DisplayAction($"Coletou {amount} {item.name}");
        Destroy(gameObject);
    }

    public void Food(){
        GameManager.instance.toEat(10);
        GameManager.instance.toDrink(10);
        Destroy(gameObject);  
    }
}