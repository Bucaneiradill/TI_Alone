using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    public static EquipmentManager instance;
    private Item equippedItem;
    public delegate void UseItem();
    public UseItem useItem;

    private void Awake()
    {
        instance = this;
    }

    public void EquipItem(Item item)
    {
        equippedItem= item;
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
