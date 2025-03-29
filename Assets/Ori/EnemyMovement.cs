using System;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEditor.Analytics;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private List<Transform> waypoints;
    [SerializeField] private NavMeshSurface navMeshSurface;
    [SerializeField] private GameObject player;
    [SerializeField] private NavMeshAgent navMeshAgent;
    
    private int waypointIndex = 0;
    
    void Start()
    {
        if (waypoints != null)
            navMeshAgent.destination = waypoints[waypointIndex].position;
        navMeshAgent.autoBraking = false;
    }

    
    void Update()
    {
        if (waypoints != null)
        {
            if (!navMeshAgent.pathPending && navMeshAgent.remainingDistance < 0.5f)
            {
                waypointIndex = (waypointIndex + 1) % waypoints.Count;
                Debug.Log(waypointIndex);
                navMeshAgent.destination = waypoints[waypointIndex].position;
            }
        }
    }
}
