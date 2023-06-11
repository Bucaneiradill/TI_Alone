using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    public static EquipmentManager instance;
    public Item equippedItem;
    public delegate void UseItem();
    public UseItem useItem;

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
                    if(EquipmentUI.instance.slots[numberPressed - 1].item != null)
                        EquipItem(EquipmentUI.instance.slots[numberPressed - 1].item);
                }
            }
        }
    }

    public void EquipItem(Item item)
    {
        equippedItem= item;
        Debug.Log($"Item equipado: {item.name}");
    }

    public void UnequipItem()
    {
        equippedItem= null;
    }

    public Item GetItem()
    {
        return equippedItem;
    }
}
