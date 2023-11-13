using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoconutAction : Interactable, IItem
{
    UIManager uiManager;
    [SerializeField] Item item;
    PlayerActions playerActions;
    MousePosition mouseDown;
    //[SerializeField] Image icon1;
    //[SerializeField] Image icon2; 

    public int amount = 1;

    private void Start()
    {
        FindOutline();
        uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        playerActions = GameObject.FindWithTag("Player").GetComponent<PlayerActions>();
        mouseDown = GameObject.FindWithTag("Mouse").GetComponent<MousePosition>();
    }

    void FixedUpdate(){
        if(mouseDown.interactable != null){ 
            if(Input.GetMouseButtonDown(1)){
                Debug.Log("Online");
                UIManager.instance.AddActions(ActionA, ActionB);
            }
        }
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
        bool spaceInventory = Inventory.instance.CheckAndAddItem(item);
        if (spaceInventory == true)
        {
            player.gameObject.GetComponent<PlayerActions>().anim.SetTrigger("Collect");
            for(int i = 0; i < amount - 1; i++)
            {
                Inventory.instance.CheckAndAddItem(item);
            }
        }
        else
        {
            uiManager.DisplayAction("Inventário cheio");
        }
    }
    /*------------------------------------------------------------------------------
    Função:     ActionA
    Descrição:  
    Entrada:    -
    Saída:      -
    ------------------------------------------------------------------------------*/
    public void ActionA(){ //Comer
        SetTarget(this);
        if(hasInteracted == true){
        GameManager.instance.toEat(10);
        GameManager.instance.toDrink(10);
        Destroy(gameObject);
        }
    }
    /*------------------------------------------------------------------------------
    Função:     ActionB
    Descrição:  
    Entrada:    -
    Saída:      -
    ------------------------------------------------------------------------------*/
    public void ActionB(){
        Debug.Log("Arvore ação B");
    }
    /*------------------------------------------------------------------------------
    Função:     ObjectPickUp
    Descrição:  
    Entrada:    -
    Saída:      -
    ------------------------------------------------------------------------------*/
    public void ObjectPickUp()
    {
        uiManager.DisplayAction($"Coletou {amount} {item.name}");
        Destroy(gameObject);
    }
    void SetTarget(Interactable newTarget)
    {
        playerActions.SetTarget(newTarget);
    }
}
