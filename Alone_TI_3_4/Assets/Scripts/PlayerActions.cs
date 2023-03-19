using System;
using UnityEngine;
using UnityEngine.AI;

public class PlayerActions : MonoBehaviour
{
    NavMeshAgent agent;
    GameObject target;
    [SerializeField] MousePosition playerAgent;
    bool isInteracting;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void FixedUpdate()
    {
        if (target)
        {
            GoToTarget(target);
        }
    }

    void GoToTarget(GameObject target)
    {
        if(!isInteracting)
        {
            playerAgent.agent.SetDestination(target.transform.position);
            isInteracting = true;
        }
        if(agent.remainingDistance < 2)
        {
            agent.SetDestination(transform.position);
            Interact(target);
        }
    }

    void Interact(GameObject target)
    {
        Destroy(target);
        target = null;
        isInteracting = false;
    }

    public void SetTarget(GameObject target)
    {
        this.target = target;
    }
}
