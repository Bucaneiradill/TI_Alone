using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AnimalMachine : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject Player;
    public string AnimalTag;
    IState state;
    public Transform Target;
    public Transform[] PatrolPoints;
    public bool HasEnergy = true;
    public float energy;
    public Animator Animator;
    

    void Start()
    {
        SetState(new AnimalPatrolState(this));
        agent = GetComponent<NavMeshAgent>();
        Animator = GetComponent<Animator>();
        energy = 3;
        Player = GameObject.Find("Player");
        Target = Player.transform;
    }

    void Update()
    {
        state?.Update();
        Animator.SetBool("HasEnergy?", HasEnergy);  
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
        return(TargetDir().magnitude < 8.0f );
    }

    

    public void Move()
    {
        
        int index = 0;
        energy -= Time.fixedDeltaTime;
        agent.speed= 3;
        Vector3 direcao = PatrolPoints[index].position-transform.position;
        if(direcao.magnitude<=1.5f)
        {
            index = Random.Range(0,4);
            Debug.Log(index);
        }
        agent.SetDestination(PatrolPoints[index].transform.position);    
         

        if(energy<=0)
        {
            HasEnergy= false;
        }   
    }            

    public void Rest()
    {
        //Debug.Log("Descansando");
        agent.speed = 0.0f;
        energy+= Time.fixedDeltaTime*1.5f;
        if(energy >= 3.0f)
        {
            HasEnergy= true;
        }
    }

    public void Chase(float speed)
    {
        Subject.instance.NotifyAll();
        energy -= Time.fixedDeltaTime;
        agent.SetDestination(Target.transform.position);
        agent.speed= speed;
         if(energy<=0)
        {
            HasEnergy= false;
        }   
    }

     public void Hunt(float speed)
    {
        
        energy -= Time.fixedDeltaTime;
        agent.SetDestination(Target.transform.position);
        agent.speed= speed;
        
         if(energy<=0)
        {
            HasEnergy= false;
        }   
    }
}
