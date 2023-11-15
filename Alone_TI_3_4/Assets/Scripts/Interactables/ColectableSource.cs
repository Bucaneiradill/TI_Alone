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
    
    public int SaveHealth;
    public GameObject obj;

    AudioSource hitAudio;
    public Item counterType;

    private void Start()
    {
        SaveHealth = health;
        hitAudio = GetComponent<AudioSource>();
        FindOutline();
    }

    public override void BaseAction()
    {
        base.BaseAction();
        player.gameObject.GetComponent<PlayerActions>().anim.SetTrigger("Interact");
    }

    public void Hit()
    {
        hitAudio?.Play();
        if (particle != null)
        {
            Instantiate(particle, particlePoint.position, Quaternion.identity);
            GameManager.instance.toHungry(1);
            GameManager.instance.toThirst(2);
        }
        else
        {
            GameManager.instance.toHungry(1);
            GameManager.instance.toThirst(2);
        }
        Item equippedItem = EquipmentManager.instance.equippedItem;
        if (equippedItem?.GetType() == counterType.GetType())
        {
            equippedItem.PerformAction(this);
        }
        else
        {
            health--;
        }
        if (health <= 0)
        {
            GameObject lootInstance;
            lootInstance = Instantiate(loot, dropPoint ? dropPoint.position : transform.position, Quaternion.identity);
            //Destroy(gameObject);
            lootInstance.gameObject.GetComponent<Object>().amount = lootAmount;
            GameObject obj;
            obj = transform.GetChild(0).gameObject;
            obj.SetActive(false);
            //time = Time.time + delay;
           gameObject.GetComponent<SpawnerItem>().time = Time.time + gameObject.GetComponent<SpawnerItem>().delay;
           health = SaveHealth;
        }
    }
}
