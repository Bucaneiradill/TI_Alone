using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BoatCollect : Interactable
{


    
    [SerializeField] Item item;
    public int amount = 1;

    private void Start()
    {
        FindOutline();
        
    }

     public override void Interact()
    {
        Debug.Log("coletado");
        base.Interact();
        GameManager.instance?.CollectBoatPart();
        

         bool spaceInventory = Inventory.instance.CheckAndAddItem(item);
        if (spaceInventory == true)
        {
            player.gameObject.GetComponent<PlayerActions>().anim.SetTrigger("Collect");
            for(int i = 0; i < amount - 1; i++)
            {
                Inventory.instance.CheckAndAddItem(item);
            }
        }
        else
        {
            UIManager.instance.DisplayAction("Inventário cheio");
        }
       Destroy(gameObject);
    }

   

    
}
