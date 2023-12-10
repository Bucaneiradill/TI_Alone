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
            // Verificar se o jogador est� dentro da esfera
            Collider[] colliders = Physics.OverlapSphere(transform.position, effectRadius);

            foreach (Collider collider in colliders)
            {
                if (collider.CompareTag("Player"))
                {
                    // O jogador est� dentro da �rea da fogueira
                    Debug.Log("Player is inside campfire radius");
                    // Fa�a o que precisar fazer quando o jogador estiver dentro da �rea
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
