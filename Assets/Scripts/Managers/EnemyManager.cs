using System;
using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEditor.Analytics;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private List<Transform> Waypoints;
    [SerializeField] private GameObject Player;
    [SerializeField] private NavMeshAgent NavMeshAgent;
    [SerializeField] private Weapon EnemyWeapon;
    [SerializeField] private float ShootCooldownInSeconds;
    [SerializeField] private Health healthManager;
    
    private int waypointIndex = 0;
    private bool isShooting;
    private bool IsPlayerInRange;
    
    void Start()
    {
        if (Waypoints != null)
            NavMeshAgent.destination = Waypoints[waypointIndex].position;
        NavMeshAgent.autoBraking = false;
        
        isShooting = false;
        IsPlayerInRange = false;
    }

    
    void Update()
    {
        if (!isShooting && IsPlayerInRange)
        {
            
            StartCoroutine(ShootingCooldown(ShootCooldownInSeconds));
            EnemyWeapon.Shoot();
        }
        else if (Waypoints.Count > 0 && !NavMeshAgent.pathPending && NavMeshAgent.remainingDistance < 0.5f)
        {
            waypointIndex = (waypointIndex + 1) % Waypoints.Count;
            NavMeshAgent.destination = Waypoints[waypointIndex].position;
        }
    }

    public void ChasePlayer()
    {
        NavMeshAgent.destination = Player.transform.position;
    }

    public void StopChasePlayer()
    {
        if (Waypoints.Count == 0)
        {
            NavMeshAgent.destination = transform.position;
        }
        else
        {
            NavMeshAgent.destination = Waypoints[waypointIndex].position;
        }
    }

    public void ShouldShootPlayer()
    {
        IsPlayerInRange = true;
    }
    
    public void ShouldNotShootPlayer()
    {
        IsPlayerInRange = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            healthManager.onDeath?.Invoke();
        }
    }

    private IEnumerator ShootingCooldown(float cooldown)
    {
        isShooting = true;
        NavMeshAgent.isStopped = true;
        yield return new WaitForSeconds(cooldown);
        NavMeshAgent.isStopped = true;
        isShooting = false;
    }
}
