using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    public static EquipmentManager instance;
    public Item equippedItem;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        string input = Input.inputString;

        if(input.Length == 1 )
        {
            if (int.TryParse(input, out int numberPressed))
            {
                if (numberPressed >= 1 && numberPressed <= EquipmentUI.instance.slots.Length)
                {
                    if (EquipmentUI.instance.slots[numberPressed - 1].item != null)
                        EquipItem(EquipmentUI.instance.slots[numberPressed - 1].item);
                    else UnequipItem();
                }
            }
        }
    }

    public void EquipItem(Item item)
    {
        if (item.isEquipable)
        {
            equippedItem = item;
            UIManager.instance.DisplayAction($"Item equipado: {item.name}");
        }
        else if (item.isConsumable)
        {
            item.PerformAction();
            EquipmentUI.instance.RemoveItem(EquipmentUI.instance.FindItem(item));
        }
    }

    public void UnequipItem()
    {
        equippedItem= null;
        UIManager.instance.DisplayAction($"Nenhum item equipado");
    }

    public Item GetItem()
    {
        return equippedItem;
    }
}
