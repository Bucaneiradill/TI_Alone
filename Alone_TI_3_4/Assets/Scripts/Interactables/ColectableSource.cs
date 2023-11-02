using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ColectableSource : Interactable
{
    [SerializeField] GameObject loot;
    [SerializeField] int lootAmount;
    [SerializeField] string lootName;
    [SerializeField] Transform dropPoint;
    [SerializeField] Transform particlePoint;
    [SerializeField] GameObject particle;
    
    public GameObject obj;

    AudioSource hitAudio;
    public ItemType counterType;

    private void Start()
    {
        hitAudio = GetComponent<AudioSource>();
        FindOutline();
    }

    public override void Interact()
    {
        base.Interact();
        player.gameObject.GetComponent<PlayerActions>().anim.SetTrigger("Interact");
        hitAudio.Play();
        if (particlePoint!= null)
        {
            Instantiate(particle, particlePoint.position, Quaternion.identity);
            GameManager.instance.toHungry(1);
            GameManager.instance.toThirst(2);
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
            //Destroy(gameObject);
            
            GameObject obj;
            obj = transform.GetChild(0).gameObject;
            obj.SetActive(false);
           
        }
    }
}
