using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colectable : Interactable
{
    UIManager uiManager;
    [SerializeField] Item item;
    [SerializeField] int amount = 1;

    private void Start()
    {
        uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }

    public override void Interact()
    {
        base.Interact();
        ObjectPickUp();
    }

    private void ObjectPickUp()
    {

        bool spaceInventory = Inventory.instance.AddItem(item, amount);
        if (spaceInventory == true)
        {
            uiManager.DisplayAction($"Coletou {amount} {item.name}");
            Destroy(gameObject);
        }
    }

    //continuação da gambiarra do MousePosition
    public void ObjectConsume()
    {
        base.Interact();
        GameManager.instance.toDrink(10);
        GameManager.instance.toEat(10);
        Debug.Log("Comeu e Bebeu");
        uiManager.DisplayAction($"Comida e água +10");
        Destroy(gameObject);
    } 
}
