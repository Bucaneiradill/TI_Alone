using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

[Serializable]
public class InventoryData 
{
    public List<Item> inventoryDataItens = new List<Item>();
    public InventoryData(List<Item> itens){
        inventoryDataItens = itens;
    }
}
