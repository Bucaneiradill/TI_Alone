using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Axe", menuName = "Inventory/Pickaxe")]
public class Pickaxe : Item
{
    public int damage = 2;
    public override void PerformAction(ColectableSource source)
    {
        source.health -= damage;
    }
}
