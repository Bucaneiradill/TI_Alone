
using System;
using UnityEngine;

[Serializable]
public class HotBarData {
public EquipmentSlot[] slots;

  public HotBarData(EquipmentSlot[] equipmentSlots){
       for(int i = 0; i < equipmentSlots.Length; i++){
           slots[i] = equipmentSlots[i];
       }
    }
}
   