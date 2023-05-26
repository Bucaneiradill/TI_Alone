using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftUI : MonoBehaviour
{
    public static CraftUI instance;
    [SerializeField] GameObject slot;
    [SerializeField] Transform ingredientsPanel;
    [SerializeField] Image itemIcon;
    [SerializeField] Button craftButton;
    public Item itemToCraft;

    private void Awake()
    {
        instance= this;
    }

    public void SetItem(Item item, bool canCraft)
    {
        itemToCraft = item;
        itemIcon.sprite = itemToCraft.icon;
        itemIcon.enabled = true;
        FillRecipe();
        craftButton.enabled = canCraft;
    }

    private void FillRecipe()
    {
        foreach (var item in itemToCraft.ingredients)
        {
            GameObject aux = Instantiate(slot, ingredientsPanel, false);
            aux.GetComponent<IngredientSlot>().SetIcon(item.icon);
            Debug.Log(aux.name);
        }
    }

    public void Craft()
    {
        CraftManager.instance.CraftItem(itemToCraft);
    }

    public void CloseWindow()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        itemToCraft = null;
        for(int i = 0; i < ingredientsPanel.childCount; i++)
        {
            Destroy(ingredientsPanel.GetChild(i).gameObject);
        }
        itemIcon.sprite = null;
    }
}
