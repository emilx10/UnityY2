using UnityEngine;
using UnityEngine.AI;

public class Player1Slow : MonoBehaviour
{
    private NavMeshAgent agent;  
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public void SlowPlayer()
    {
        agent.speed = 2.5f;
        
    }

    public void LogMessage(string message)
    {  
        Debug.Log(message);  
    }



}
