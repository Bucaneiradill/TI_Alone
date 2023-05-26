using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IngredientSlot : MonoBehaviour
{
    public Item ingredient;
    [SerializeField] Image icon;

    public void SetIcon(Sprite icon)
    {
        this.icon.sprite = icon;
    }
}
