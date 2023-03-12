using UnityEngine;
using UnityEngine.AI;

public class MousePosition : MonoBehaviour
{
    [SerializeField] Camera mainCamera;
    [SerializeField] LayerMask layerMask;
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] NavMeshAgent agent;

    void Update()
    {
        //Pegando o ponto em que o mouse está
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out RaycastHit rayCastHit, float.MaxValue, layerMask))
        {
            transform.position = rayCastHit.point;
            //Verificando o input e qual layer está sendo atingida
            if (Input.GetMouseButtonDown(1) && 
                rayCastHit.collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
            {
                //Ao clicar com o botão direito, cria o destino do player
                agent.SetDestination(rayCastHit.point);
            }
        }
    }
}
