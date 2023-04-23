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
                Interactable interactable = rayCastHit.collider.gameObject.GetComponent<Interactable>();
                if (interactable != null)
                {
                    SetTarget(interactable);
                } else {
                    playerActions.RemoveTarget();
                    playerActions.MoveToPoint(rayCastHit.point);
                }
            }

            //gambiarra sinistra abaixo s� pra testar diferentes tipos de intera��o
            else if (Input.GetMouseButtonDown(1))
            {
                Colectable colectable = rayCastHit.collider.gameObject.GetComponent<Colectable>();
                if (colectable != null)
                {
                    colectable.ObjectConsume();
                }
            }
        }
    }

    void SetTarget(Interactable newTarget)
    {
        playerActions.SetTarget(newTarget);
    }
}
