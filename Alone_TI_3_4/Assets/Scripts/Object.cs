using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : Interactable
{
    [SerializeField] GameObject loot;
    [SerializeField] int lootAmount;
    [SerializeField] string lootName;
    UIManager uiManager;

    private void Start()
    {
        uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }

    public override void Interact()
    {
        base.Interact();
        Instantiate(loot, transform.position, Quaternion.identity);
        uiManager.DisplayAction($"Coletou {lootAmount} {lootName}");
        Destroy(gameObject);
    }
}
