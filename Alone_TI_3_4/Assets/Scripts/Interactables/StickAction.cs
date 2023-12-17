using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickAction : Interactable
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
            playerActions.Collect();
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
    public override void SecundaryAction(){}
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
}
