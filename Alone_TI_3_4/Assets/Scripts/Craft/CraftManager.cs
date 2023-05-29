using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftManager : MonoBehaviour
{
    public static CraftManager instance;

    private void Awake()
    {
        instance = this;
    }

    public void CraftItem(Item item)
    {
        foreach (Item ingredient in item.ingredients)
        {
            Inventory.instance.RemoveItem(ingredient);
        }
        Inventory.instance.AddItem(item);
    }
}
