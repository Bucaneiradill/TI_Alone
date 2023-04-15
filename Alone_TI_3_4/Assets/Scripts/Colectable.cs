using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colectable : Interactable
{
    UIManager uiManager;
    [SerializeField] int lootAmount;
    [SerializeField] string lootName;

    //Esse c�digo � pra itens que s�o adicionados no invent�rio assim que o player interage
    //Tipo graveto, pedra colet�vel, etc
    //Talvez isso possa ser usado em ba�s tbm 
    private void Start()
    {
        uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }

    public override void Interact()
    {
        base.Interact();
        uiManager.DisplayAction($"Coletou {lootAmount} {lootName}");
        //Chama a fun��o de adicionar no invent�rio (quando tiver um invent�rio)
        Destroy(gameObject);
    }
}
