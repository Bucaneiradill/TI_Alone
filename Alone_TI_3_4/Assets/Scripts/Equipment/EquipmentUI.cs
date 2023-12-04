using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentUI : MonoBehaviour
{
    public static EquipmentUI instance;
    public EquipmentSlot[] slots;
    [SerializeField] Transform selection;
    public int selectedSlot = 0;

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
        selection.position = slots[0].transform.position;
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
                if(selectedSlot == i) EquipmentManager.instance.EquipItem(item);
                slots[i].SetItem(item);
                return;
            }
        }
    }

    public void UpdateHotbar(int index)
    {
        selectedSlot = index;
        selection.position = slots[index].transform.position;
    }

    public void RemoveItem(int slotIndex)
    {
        slots[slotIndex].ClearSlot();
    }
    
    //save da HotBar
    public HotBarData GetHotBar(){
        HotBarData data = new HotBarData(slots);
        return data;
    }
    //Load da HotBar
    public void SetHotBar(EquipmentSlot[] equipmentSlots){
      for(int i = 0; i < equipmentSlots.Length; i++){
            slots[i] = equipmentSlots[i];
       }
    }
}
