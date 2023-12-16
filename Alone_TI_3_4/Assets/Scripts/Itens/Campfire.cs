using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Campfire : Interactable
{
    bool turnedOn;
    [SerializeField] float effectRadius = 4f;
    [SerializeField] Light fireLight;
    [SerializeField] GameObject fireObject;

    public override void Interact()
    {
        base.Interact();
        turnedOn = !turnedOn;
        fireLight.gameObject.SetActive(turnedOn);
        fireObject.SetActive(turnedOn);
        if (!turnedOn)
        {
            GameManager.instance.nearFire = false;
        }
        else
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, effectRadius);

            foreach (Collider collider in colliders)
            {
                if (collider.CompareTag("Player"))
                {
                    GameManager.instance.nearFire = true;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (turnedOn)
        {
            if (other.CompareTag("Player"))
            {
                GameManager.instance.nearFire = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.instance.nearFire = false;
        }
    }
}
