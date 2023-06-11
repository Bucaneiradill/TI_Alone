using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Food")]
public class Food : Item
{
    public override void PerformAction(ColectableSource source)
    {
        // Lógica específica para ação da comida
    }
}
