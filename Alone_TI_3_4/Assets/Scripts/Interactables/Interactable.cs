using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Interactable : MonoBehaviour
{
    public float radius = 3f;
    public Transform player;
    protected PlayerActions playerActions;
    public int button;
    public int health = 5;

    public Outline outline;
    [SerializeField] Texture2D exclamationCursor;

    public void FindOutline()
    {
        if (gameObject.TryGetComponent(out Outline outline))
        {
            this.outline = outline;
        }
        else
        {
            this.outline = gameObject.AddComponent<Outline>();
        }
        this.outline.enabled = false;
    }
    public void Interact(Transform player)
    {
        playerActions = player.gameObject.GetComponent<PlayerActions>();
        if(button == 0){
            Debug.Log("Ação basica" + gameObject.name);
            BaseAction();
        }else{
            Debug.Log("Menu de ação" + gameObject.name);
            UIManager.instance.AddActions(BaseAction, SecundaryAction);
        }
    }

    public virtual void BaseAction(){}
    public virtual void SecundaryAction(){}

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    public void ShowOutline()
    {
        if (outline != null)
        {
            outline.enabled = true;
        }
        Cursor.SetCursor(exclamationCursor, Vector2.zero, CursorMode.Auto);
    }

    public void HideOutline()
    {
        if (outline != null)
        {
            outline.enabled = false;
        }
    }

    public virtual void Hit(){}
    public virtual void ObjectPickUp(){}
}
