using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentUI : MonoBehaviour
{
    public static EquipmentUI instance;
    public EquipmentSlot[] slots;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        slots = GetComponentsInChildren<EquipmentSlot>();
        for(int i = 0; i < slots.Length; i++)
        {
            slots[i].slotNumber.text = (i + 1).ToString();
        }
    }

    public int FindItem(Item item)
    {
        for(int i = 0; i < slots.Length - 1; i++)
        {
            if(slots[i].item == item)
            {
                return i;
            }
        }
        return -1;
    }

    public void SetItem(Item item)
    {
        for(int i = 0; i < slots.Length; i++)
        {
            if (slots[i].item == null)
            {
                slots[i].SetItem(item);
                return;
            }
        }
    }

    public void RemoveItem(int slotIndex)
    {
        slots[slotIndex].ClearSlot();
    }
}
