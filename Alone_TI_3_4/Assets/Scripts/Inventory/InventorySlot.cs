using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    [SerializeField] Image icon; 
    [SerializeField] Button removeButton;
    Item item;

    public void AddItemSlot(Item newItem){
        item = newItem;
        icon.sprite = item.icon;
        icon.enabled = true;
        icon.preserveAspect = true;
        removeButton.interactable = true;
    }

    public void ClearSlot(){ 
        item = null;
        icon.sprite = null;
        icon.enabled = false;
        removeButton.interactable = false;
    }

    public void OnRemoveButton(){
        Inventory.instance.RemoveItem(item);
    }

    public void OnClickItem()
    {
        if (item.isEquipable)
        {
            if (EquipmentUI.instance.FindItem(item) == -1)
            {
                EquipmentUI.instance.SetItem(item);
            }
        }
        else if (item.isConsumable)
        {
            GameManager.instance.toEat(10);
            GameManager.instance.toDrink(10);
            OnRemoveButton();
        }
    }
}
