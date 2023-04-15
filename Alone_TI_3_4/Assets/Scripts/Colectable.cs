using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colectable : Interactable
{
    UIManager uiManager;
    [SerializeField] int lootAmount;
    [SerializeField] string lootName;

    //Esse código é pra itens que são adicionados no inventário assim que o player interage
    //Tipo graveto, pedra coletável, etc
    //Talvez isso possa ser usado em baús tbm 
    private void Start()
    {
        uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }

    public override void Interact()
    {
        base.Interact();
        uiManager.DisplayAction($"Coletou {lootAmount} {lootName}");
        //Chama a função de adicionar no inventário (quando tiver um inventário)
        Destroy(gameObject);
    }
}
