using System;
using UnityEngine;
using UnityEngine.AI;

public class MousePosition : MonoBehaviour
{
    [SerializeField] Camera mainCamera;
    [SerializeField] LayerMask layerMask;
    [SerializeField] PlayerActions player;
    [SerializeField] NavMeshAgent agent;

    void Update()
    {
        //Pegando o ponto em que o mouse está
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out RaycastHit rayCastHit, float.MaxValue, layerMask))
        {
            transform.position = rayCastHit.point;
            //Verificando o input e qual layer está sendo atingida
            if (Input.GetMouseButtonDown(0))
            {
                agent.SetDestination(rayCastHit.point);
                if (rayCastHit.collider.gameObject.layer == LayerMask.NameToLayer("Tree"))
                {
                    player.CutTree();
                }
            }
        }
    }
}
