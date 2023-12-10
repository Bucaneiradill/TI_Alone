using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Campfire : Interactable
{
    bool turnedOn;
    [SerializeField] float effectRadius = 4f;

    public override void Interact()
    {
        base.Interact();
        turnedOn = !turnedOn;
    }

    public override void Update()
    {
        base.Update();
        if (turnedOn)
        {
            // Verificar se o jogador está dentro da esfera
            Collider[] colliders = Physics.OverlapSphere(transform.position, effectRadius);

            foreach (Collider collider in colliders)
            {
                if (collider.CompareTag("Player"))
                {
                    // O jogador está dentro da área da fogueira
                    Debug.Log("Player is inside campfire radius");
                    // Faça o que precisar fazer quando o jogador estiver dentro da área
                }
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, effectRadius);
    }
}
