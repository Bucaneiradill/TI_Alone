using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentSlot : MonoBehaviour
{
    public Image itemImage;
    public Item item;

    public void SetItem(Item item)
    {
        this.item = item;
        itemImage.sprite = item.icon;
    }

    public void ClearSlot()
    {
        item = null;
        itemImage.sprite = null;
    }
}
