using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colectable : MonoBehaviour
{
    [SerializeField] Item item;

    private void Start()
    {

    }

    public void ObjectPickUp()
    {
        bool spaceInventory = Inventory.instance.items.Count < Inventory.instance.inventorySpace;
        if (spaceInventory == true)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ObjectPickUp();
        }
    }
}
