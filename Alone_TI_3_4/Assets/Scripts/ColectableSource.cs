using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColectableSource : Interactable
{
    [SerializeField] GameObject loot;
    [SerializeField] int lootAmount;
    [SerializeField] string lootName;
    [SerializeField] Transform dropPoint;

    //Minha ideia � q esse c�digo seja s� pra coisas tipo �rvore, pedra, etc.
    //Ent nada daqui vai adicionar coisas no invent�rio, s� dropar o loot dps de ser quebrado.
    //Claro, a gente pode mudar pro item ser adicionado automativamente assim q quebrar a fonte dele.
    //Isso tudo a gente ainda pode discutir, s� queria separar cada tipo de objeto msm
    public override void Interact()
    {
        base.Interact();
        //Caso o objeto seja adicionado automaticamente depois que destruir a fonte, s� trocar 
        //o instantiate pela fun��o de adicionar no invent�rio e ligar a mensagem dnv
        Instantiate(loot, dropPoint ? dropPoint.position : transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}