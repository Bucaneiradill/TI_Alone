using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftUI : MonoBehaviour
{
    [SerializeField] GameObject slot;
    private Transform ingredientsPanel;
    public Item itemToCraft;

    private void OnEnable()
    {
        foreach (var item in itemToCraft.ingredients)
        {
            GameObject aux = Instantiate(slot, ingredientsPanel);
            aux.GetComponent<IngredientSlot>().SetIcon(item.icon);
        }
    }
    private void OnDisable()
    {
        itemToCraft = null;
        for(int i = 0; i < ingredientsPanel.childCount; i++)
        {
            Destroy(ingredientsPanel.transform.GetChild(i).gameObject);
        }
    }
}
