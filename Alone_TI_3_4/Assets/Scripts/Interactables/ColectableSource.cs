using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColectableSource : Interactable
{
    [SerializeField] GameObject loot;
    [SerializeField] int lootAmount;
    [SerializeField] string lootName;
    [SerializeField] Transform dropPoint;
    [SerializeField] Transform particlePoint;
    [SerializeField] GameObject particle;
    AudioSource hitAudio;
    public ItemType counterType;

    private void Start()
    {
        hitAudio = GetComponent<AudioSource>();
    }

    public override void Interact()
    {
        base.Interact();
        hitAudio.Play();
        if (particlePoint!= null)
        {
            Instantiate(particle, particlePoint.position, Quaternion.identity);
        }
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
