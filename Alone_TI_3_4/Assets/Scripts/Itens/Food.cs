using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Food")]
public class Food : Item
{
    public override void PerformAction(ColectableSource source)
    {
        // L�gica espec�fica para a��o da comida
    }
}