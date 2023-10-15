using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AnimalMachine : MonoBehaviour
{
    NavMeshAgent agent;
    IState state;
    public Transform Target;
    public Transform[] PatrolPoints;
    public float speed;
    public float energy;

    void Start()
    {
        SetState(new AnimalPatrolState(this));
        agent = GetComponent<NavMeshAgent>();
        energy = 3;
    }

    void Update()
    {
        state?.Update();
    }

    public void SetState(IState state)
    {
        this.state?.Exit();
        this.state = state;
        this.state?.Enter();
    }

    public Vector3 TargetDir()
    {
        Vector3 dir = Target.position-transform.position;
        return dir;
    }

    public bool IsNearTarget()
    {
        return(TargetDir().magnitude < 6.0f );
    }

    public void Move()
    {
        int index = 0;
        energy -= Time.fixedDeltaTime;
        Vector3 direcao = PatrolPoints[index].position-transform.position;
        if(direcao.magnitude<=1.5f)
        {
            if(index == 2 && direcao.magnitude <= 1.5f)
            {
                index = -1;
            }
            index++; 
        }
        agent.SetDestination(PatrolPoints[index].transform.position);          
    }            

    public void Chase()
    {
        Subject.instance.NotifyAll();
        energy -= Time.fixedDeltaTime;
        agent.SetDestination(Target.transform.position);
    }
}
