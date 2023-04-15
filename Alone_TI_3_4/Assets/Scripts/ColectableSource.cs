using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColectableSource : Interactable
{
    [SerializeField] GameObject loot;
    [SerializeField] int lootAmount;
    [SerializeField] string lootName;
    UIManager uiManager;

    private void Start()
    {
        uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }

    //Minha ideia é q esse código seja só pra coisas tipo árvore, pedra, etc.
    //Ent nada daqui vai adicionar coisas no inventário, só dropar o loot dps de ser quebrado.
    //Claro, a gente pode mudar pro item ser adicionado automativamente assim q quebrar a fonte dele.
    //Isso tudo a gente ainda pode discutir, só queria separar cada tipo de objeto msm
    public override void Interact()
    {
        base.Interact();
        //Caso o objeto seja adicionado automaticamente depois que destruir a fonte, só trocar 
        //o instantiate pela função de adicionar no inventário e ligar a mensagem dnv
        Instantiate(loot, transform.position, Quaternion.identity);
        uiManager.DisplayAction($"Coletou {lootAmount} {lootName}");
        Destroy(gameObject);
    }
}
