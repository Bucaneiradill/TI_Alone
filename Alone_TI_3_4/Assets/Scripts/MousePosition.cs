using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class MousePosition : MonoBehaviour
{
    [SerializeField] Camera mainCamera;
    [SerializeField] LayerMask layerMask;
    [SerializeField] PlayerActions playerActions;
    public NavMeshAgent agent;
    Interactable interactable;

    void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
            return;
        }
        interactable?.HideOutline();
        interactable = null;
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out RaycastHit rayCastHit, float.MaxValue, layerMask))
        {
            transform.position = rayCastHit.point;
            interactable = rayCastHit.collider.gameObject.GetComponentInParent<Interactable>();
            if (interactable != null)
            {
                interactable.ShowOutline();
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
    }

    void SetTarget(Interactable newTarget)
    {
        playerActions.SetTarget(newTarget);
    }
}
