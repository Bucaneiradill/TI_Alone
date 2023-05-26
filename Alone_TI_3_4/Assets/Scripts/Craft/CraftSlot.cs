using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftSlot : MonoBehaviour
{
    public Item item;
    [SerializeField] Image icon;
    GameObject recipePanel;
    public bool canCraft;

    private void Start()
    {
        icon.sprite = item.icon;
        icon.enabled = true;
        icon.preserveAspect = true;
        //tenho q pegar referência do painel
        recipePanel = InventoryUI.instance.recipeUI;
    }

    //Verifica se tem todos os itens no inventário
    public void CheckRequiredItems()
    {
        canCraft = true;
        foreach (Item item in item.ingredients)
        {
            if (!Inventory.instance.SearchItem(item))
            {
                canCraft = false;
            }
        }
        recipePanel.GetComponent<CraftUI>().SetItem(item, canCraft);
        recipePanel.SetActive(true);
    }
}
