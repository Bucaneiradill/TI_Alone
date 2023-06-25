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

    void Update()
    {
        if(EventSystem.current.IsPointerOverGameObject()) return;
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out RaycastHit rayCastHit, float.MaxValue, layerMask))
        {
            transform.position = rayCastHit.point;
            if (Input.GetMouseButtonDown(0))
            {
                Interactable interactable = rayCastHit.collider.gameObject.GetComponentInParent<Interactable>();
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
