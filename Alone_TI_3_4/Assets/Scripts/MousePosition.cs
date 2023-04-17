using System;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.AI;

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
                Interactable interactable = rayCastHit.collider.gameObject.GetComponent<Interactable>();
                // Debug.Log(interactable.gameObject.name);
                // if (TryGetComponent<Interactable>(rayCastHit.transform, out Interactable interactable))
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
