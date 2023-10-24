using System;
using UnityEngine;
using UnityEngine.AI;

public class PlayerActions : MonoBehaviour
{
    NavMeshAgent agent;
    [SerializeField] Interactable target;
    //bool isInteracting;
    public Animator anim;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void FixedUpdate()
    {
        if (target != null)
        {
            agent.SetDestination(target.transform.position);
            FaceTarget();
        }
        if(agent.remainingDistance < 0.5f)
        {
            anim.SetInteger("State", 0);
        }
    }

    public void MoveToPoint(Vector3 point){
        agent.SetDestination(point);
        anim.SetInteger("State", 1);
    }

    public void FollowTarget(Interactable newTarget){
        agent.updateRotation = false;
        agent.stoppingDistance = newTarget.radius * .8f;
    }

    public void StopFollowingTarget(){
        agent.updateRotation = true;
        agent.stoppingDistance = 0f;
        target = null;
        anim.SetInteger("State", 0);
    }

    void FaceTarget(){
        Vector3 directon = (target.transform.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(directon.x, 0f, directon.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.fixedDeltaTime * 5);
    }

    public void SetTarget(Interactable newTarget)
    {
        if(newTarget != target)
        {
            if(target != null)
            {
                target.OnDefocused();
            }
            target = newTarget;
            FollowTarget(newTarget);
        }
        
        newTarget.OnFocus(gameObject.transform);
    }

    public void RemoveTarget(){
        if(target != null)
        {
            target.OnDefocused();
        }
        target = null;
        StopFollowingTarget();
    }
}
