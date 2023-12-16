using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Interactable : MonoBehaviour
{
    public float radius = 3f;
    public Transform player;
    public string textAction1 = null;
    public string textAction2 = "Cancelar";
    protected PlayerActions playerActions;
    public int button;
    public int health = 5;
    private Renderer renderer;
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
            BaseAction();
        }else{
            renderer = GetComponentInChildren<Renderer>();
            Vector3 offset = renderer.bounds.center;
            UIActions.instance.AddActions(BaseAction, SecundaryAction, offset, textAction1, textAction2);
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
}
