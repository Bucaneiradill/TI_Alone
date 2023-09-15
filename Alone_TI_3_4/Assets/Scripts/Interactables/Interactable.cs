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

    public void FindOutline()
    {
        Debug.Log("FindOutline");
        if (gameObject.TryGetComponent(out Outline outline))
        {
            this.outline = outline;
            Debug.Log("Found outline in " + gameObject.layer.ToString());
        }
        else
        {
            this.outline = gameObject.AddComponent<Outline>();
            Debug.Log("Created outline in " + gameObject.layer);
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
    }

    public void HideOutline()
    {
        if (outline != null)
        {
            outline.enabled = false;
        }
    }
}
