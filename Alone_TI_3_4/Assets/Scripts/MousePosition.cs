using System;
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
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out RaycastHit rayCastHit, float.MaxValue, layerMask))
        {
            transform.position = rayCastHit.point;
            if (Input.GetMouseButtonDown(0))
            {
                agent.SetDestination(rayCastHit.point);
                //targetObj = rayCastHit.collider.gameObject;
                //if (targetObj.layer == LayerMask.NameToLayer("Tree") && playerActions != null)
                //{
                //    playerActions.SetTarget(targetObj);
                //}
            }
        }
    }
}
