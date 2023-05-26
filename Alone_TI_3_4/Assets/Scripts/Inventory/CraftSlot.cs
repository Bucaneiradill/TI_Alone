using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftSlot : MonoBehaviour
{
    public Item item;
    [SerializeField] Image icon;
    GameObject recipePanel;
    public bool canCraft = false;

    private void Start()
    {
        icon.sprite = item.icon;
        icon.enabled = true;
        icon.preserveAspect = true;
        //tenho q pegar referência do painel
    }

    //Verifica se tem todos os itens no inventário
    public void CheckRequiredItems()
    {
        foreach (Item item in item.ingredients)
        {
            if (!Inventory.instance.SearchItem(item))
            {
                canCraft = false;
            }
        }
        canCraft = true;
        recipePanel.SetActive(true);
    }

    //Remove os itens necessários e cria o novo item
    public void CraftItem()
    {
        foreach(Item item in item.ingredients)
        {
            Inventory.instance.RemoveItem(item);
        }
        Inventory.instance.AddItem(item);
    }
}
