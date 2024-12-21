using UnityEngine;
using UnityEngine.AI;

public class Movement : MonoBehaviour
{
    public Transform EndGoal;
    void Start()
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.destination = EndGoal.position;
    }

    
    
    
        
    
}
