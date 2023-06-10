using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    [SerializeField] Image icon; 
    [SerializeField] Button removeButton;
    [SerializeField] int stackSize;
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
       // stackSize = -1;
        icon.sprite = null;
        icon.enabled = false;
        removeButton.interactable = false;
    }

    public void OnRemoveButton(){
        stackSize -= 1;
        if(stackSize <= 0){
            Inventory.instance.RemoveItem(item);
        }
    }

    public bool RoomLeftInStack(int AmountToAdd, out int AmountRemaining){
        AmountRemaining = item.maxStackSize - stackSize;
        return RoomLeftInStack (AmountToAdd);
    }

    public bool RoomLeftInStack(int AmountToAdd){
        if(stackSize + AmountToAdd <= item.maxStackSize) return true;
        else return false;
    }

    public void AddStackSlot(int stackAdd){
        stackSize -= stackAdd;
    }

    public void RemoveStackSlot(int stackRemove){
        stackSize -= stackRemove;
    }

    public void EquipItem()
    {
        if (item.isEquipable)
        {
            EquipmentUI.instance.SetItem(item);
        }
    }
}
