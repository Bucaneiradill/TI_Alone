using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColectableSource : Interactable
{
    [SerializeField] GameObject loot;
    [SerializeField] int lootAmount;
    [SerializeField] string lootName;
    [SerializeField] Transform dropPoint;
    public ItemType counterType;
    public override void Interact()
    {
        base.Interact();
        if(EquipmentManager.instance.equippedItem?.itemType == counterType)
        {
            EquipmentManager.instance.equippedItem.PerformAction(this);
        }
        else
        {
            health--;
        }
        if (health <= 0)
        {
            Instantiate(loot, dropPoint ? dropPoint.position : transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
