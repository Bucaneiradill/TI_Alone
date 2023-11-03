using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Interactable : MonoBehaviour
{
    public float radius = 3f;

    bool isFocus = false;
    public Transform player;

    bool hasInteracted = false;

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

    public virtual void Interact()
    {
        
    }

    private void Update()
    {
        if (isFocus && !hasInteracted)
        {
            float distance = Vector3.Distance(player.position, transform.position);
            if(distance <= radius)
            {
                Interact();
                hasInteracted= true;
            }
        }
    }

    public void OnFocus(Transform playerTransform)
    {
        isFocus = true;
        player= playerTransform;
        hasInteracted = false;
    }

    public void OnDefocused()
    {
        isFocus = false;
        player = null;
        hasInteracted = false;
    }

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
