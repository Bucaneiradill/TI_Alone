using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CraftUI : MonoBehaviour
{
    public static CraftUI instance;
    [SerializeField] GameObject slot;
    [SerializeField] GameObject craftWindow;
    [SerializeField] Transform ingredientsPanel;
    [SerializeField] Image itemIcon;
    [SerializeField] Button craftButton;
    [SerializeField] GameObject craftSlot;
    public Item itemToCraft;

    private void Awake()
    {
        instance= this;
    }

    private void Start()
    {
        Item[] itens = Resources.LoadAll<Item>("Craftable");

        foreach (Item item in itens)
        {
            Instantiate(craftSlot, transform).GetComponent<CraftSlot>().item = item;
        }
    }

    public void SetItem(Item item, bool canCraft)
    {
        if(item != itemToCraft)
        {
            ClearPanel();
        }
        itemToCraft = item;
        itemIcon.sprite = itemToCraft.icon;
        itemIcon.enabled = true;
        FillRecipe();
        craftButton.enabled = canCraft;
        craftWindow.SetActive(true);
    }

    private void FillRecipe()
    {
        foreach (var item in itemToCraft.ingredients)
        {
            GameObject aux = Instantiate(slot, ingredientsPanel, false);
            aux.GetComponent<IngredientSlot>().SetIcon(item.icon);
        }
    }

    public void Craft()
    {
        CraftManager.instance.CraftItem(itemToCraft);
    }

    public void CloseWindow()
    {
        craftWindow.SetActive(false);
        ClearPanel();
    }

    private void ClearPanel()
    {
        itemToCraft = null;
        for(int i = 0; i < ingredientsPanel.childCount; i++)
        {
            Destroy(ingredientsPanel.GetChild(i).gameObject);
        }
        itemIcon.sprite = null;
    }
}
