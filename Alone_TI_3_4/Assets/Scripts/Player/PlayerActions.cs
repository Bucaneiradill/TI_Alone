using System;
using UnityEngine;
using UnityEngine.AI;

public class PlayerActions : MonoBehaviour
{
    public NavMeshAgent agent;
    public Interactable target;
    public Animator anim;
    public bool canAct = true;
    float initialSpeed;
    public bool IsWalking = false;
    public float walkSpeed;
    public float runSpeed;
    public static PlayerActions PlayerInstance;

    void Awake()
    {
        PlayerInstance = this;
    }

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void FixedUpdate()
    {
       // Debug.Log(agent.velocity.magnitude);
        if(agent.velocity.magnitude >= 0){
            anim.SetFloat("Speed", agent.velocity.magnitude);
            FaceTarget();
        }
        if(target == null) return;
        if(Vector3.Distance(transform.position, target.transform.position) < target.radius){
            target.Interact(this.transform);
            agent.ResetPath();
            target = null;
        }    
        Walk();
    }
    public void MoveToPoint(Vector3 point){
        agent.SetDestination(point);
        anim.SetInteger("State", 1);
    }

    public void FollowTarget(Interactable newTarget){
        agent.updateRotation = false;
        //agent.stoppingDistance = newTarget.radius * .8f;
    }

    public void StopFollowingTarget(){
        agent.updateRotation = true;
        agent.stoppingDistance = 0f;
        target = null;
        anim.SetInteger("State", 0);
    }

    void FaceTarget(){
        if(target == null) return;
        Debug.Log("Olhei " + target.name) ;
        Vector3 directon = (target.transform.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(directon.x, 0f, directon.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.fixedDeltaTime * 5);
    }

    public void SetTarget(Interactable newTarget, Vector3 point, int button)
    {
        RemoveTarget();
        MoveToPoint(point);
        if(newTarget == null) return;
        if(newTarget != target){
            target = newTarget;
            target.button = button;            
            FollowTarget(newTarget);           
        }
    }

    public void RemoveTarget(){
        target = null;
        StopFollowingTarget();
    }

    public void DisableActions()
    {
        initialSpeed = agent.speed;
        agent.speed = 0;
        canAct = false;
    }

    public void EnableActions()
    {
        agent.speed = initialSpeed;
        canAct = true;
    }

    public void Walk()
    {
        if (Input.GetKey(KeyCode.LeftShift)){ 
            anim.SetBool("Stealth", IsWalking);
            agent.speed = walkSpeed;
            IsWalking = true;
                
        } 
        else{
            anim.SetBool("Stealth", IsWalking);
            agent.speed = runSpeed;
            IsWalking = false;
        }
    }
    public void Collect(){
        Debug.Log("Collect");
        anim.SetTrigger("Collect");
    }
    public void InteractSource(){
        anim.SetTrigger("Interact");
    }
}
