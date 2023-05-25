using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftSlot : MonoBehaviour
{
    public Item item;
    [SerializeField] Image icon;

    private void Start()
    {
        icon.sprite = item.icon;
        icon.enabled = true;
        icon.preserveAspect = true;
    }

    //Verifica se tem todos os itens no invent�rio
    public void CheckRequiredItems()
    {
        foreach (Item item in item.ingredients)
        {
            if (!Inventory.instance.SearchItem(item))
            {
                Debug.Log("N�o possui todos os itens");
                return;
            }
        }
        CraftItem();
    }

    //Remove os itens necess�rios e cria o novo item
    private void CraftItem()
    {
        foreach(Item item in item.ingredients)
        {
            Inventory.instance.RemoveItem(item);
        }
        Inventory.instance.AddItem(item);
    }
}
