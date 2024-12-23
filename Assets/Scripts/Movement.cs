using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    public Transform EndGoal;
    public NavMeshSurface surface;
    public int AreaCost;
    public NavMeshAgent agent;
    public Text textPopup;
    void Start()
    {
        agent.SetAreaCost(NavMesh.GetAreaFromName("SkinnyObstacle"), AreaCost);
        agent.destination = EndGoal.position;
        textPopup.gameObject.SetActive(false);
        
    }
    private void Update()
    {
        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
            textPopup.gameObject.SetActive(true);
        }
    }






}
