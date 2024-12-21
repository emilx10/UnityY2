using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

public class Movement : MonoBehaviour
{
    public Transform EndGoal;
    public NavMeshSurface surface;
    public int AreaCost;
    void Start()
    {

        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.SetAreaCost(NavMesh.GetAreaFromName("SkinnyObstacle"), AreaCost);
        agent.destination = EndGoal.position;

        
    }

    
    
    
        
    
}
