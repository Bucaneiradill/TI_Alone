using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentSlot : MonoBehaviour
{
    public Image itemImage;
    public Item item;
    public Text slotNumber;

    public void SetItem(Item item)
    {
        this.item = item;
        itemImage.sprite = item.icon;
        itemImage.enabled = true;
    }

    public void ClearSlot()
    {
        item = null;
        itemImage.sprite = null;
        itemImage.enabled = false;
    }
}
