using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField] PlayerActions playerActions;
    private void OnMouseDown()
    {
        Debug.Log("Clicou em" + gameObject.name);
        playerActions.SetTarget(gameObject);
    }
}
