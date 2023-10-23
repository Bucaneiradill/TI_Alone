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
        //tenho q pegar refer�ncia do painel
        recipePanel = InventoryUI.instance.recipeUI;
    }

    //Verifica se tem todos os itens no invent�rio
    public void CheckRequiredItems()
    {
        List<Item> itensCopy = new List<Item>();
        itensCopy.AddRange(Inventory.instance.items.ToArray());
        canCraft = true;
        foreach (Item item in item.ingredients)
        {
            if (!itensCopy.Contains(item))
            {
                canCraft = false;
            }
            itensCopy.Remove(item);
        }
        recipePanel.GetComponent<CraftUI>().ClearPanel();
        recipePanel.GetComponent<CraftUI>().SetItem(item, canCraft);
    }
}
