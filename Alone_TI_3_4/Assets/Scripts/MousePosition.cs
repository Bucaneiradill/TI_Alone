using System;
using UnityEngine;
using UnityEngine.AI;

public class MousePosition : MonoBehaviour
{
    [SerializeField] Camera mainCamera;
    [SerializeField] LayerMask layerMask;
    [SerializeField] PlayerActions playerActions;
    GameObject targetObj;
    public NavMeshAgent agent;

    void Update()
    {
        //Pegando o ponto em que o mouse está
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out RaycastHit rayCastHit, float.MaxValue, layerMask))
        {
            transform.position = rayCastHit.point;
            //Verificando o input
            if (Input.GetMouseButtonDown(0))
            {
                agent.SetDestination(rayCastHit.point);
                //Pegando referência do objeto pai do GameObject pra n interagir só com o tronco da árvore
                targetObj = rayCastHit.collider.gameObject;
                if (targetObj.layer == LayerMask.NameToLayer("Tree") && playerActions != null)
                {
                    playerActions.SetTarget(targetObj);
                }
            }
        }
    }
}
