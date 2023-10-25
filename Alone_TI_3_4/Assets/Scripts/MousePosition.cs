using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class MousePosition : MonoBehaviour
{
    [SerializeField] Camera mainCamera;
    [SerializeField] LayerMask layerMask;
    [SerializeField] PlayerActions playerActions;
    [SerializeField] Texture2D exclamationCursor;
    public NavMeshAgent agent;
    Interactable interactable;

    void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject()) return;
        interactable?.HideOutline();
        interactable = null;
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out RaycastHit rayCastHit, float.MaxValue, layerMask))
        {
            transform.position = rayCastHit.point;
            interactable = rayCastHit.collider.gameObject.GetComponentInParent<Interactable>();
            if(interactable != null)
            {
                interactable.ShowOutline();
                Cursor.SetCursor(exclamationCursor, Vector2.zero, CursorMode.Auto);
            }
            else
            {
                Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
            }
            if (Input.GetMouseButtonDown(0))
            {
                if (interactable != null)
                {
                    SetTarget(interactable);
                } else {
                    playerActions.RemoveTarget();
                    playerActions.MoveToPoint(rayCastHit.point);
                }
            }
        }
        else
        {
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        }
    }

    void SetTarget(Interactable newTarget)
    {
        playerActions.SetTarget(newTarget);
    }
}
