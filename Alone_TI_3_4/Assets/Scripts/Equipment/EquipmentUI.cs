using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentUI : MonoBehaviour
{
    public static EquipmentUI instance;
    EquipmentSlot[] slots;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        slots = GetComponentsInChildren<EquipmentSlot>();
    }

    public void SetItem(Item item, int slotIndex)
    {
        slots[slotIndex].SetItem(item);
    }

    public void RemoveItem(int slotIndex)
    {
        slots[slotIndex].ClearSlot();
    }
}
