using UnityEngine;
using UnityEngine.AI;

public class PlayerActions : MonoBehaviour
{
    NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    //Ainda n�o terminei sabaga�a
    public void CutTree()
    {
        if(agent.remainingDistance > 1.5)
        {
            Debug.Log("Cut tree");
            agent.isStopped = true;
        }
    }
}
