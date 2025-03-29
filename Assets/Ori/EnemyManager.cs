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
    
    private int waypointIndex = 0;
    private bool isShooting;
    private bool shouldShoot;
    private IEnumerator shootConroutine;
    
    void Start()
    {
        if (Waypoints != null)
            NavMeshAgent.destination = Waypoints[waypointIndex].position;
        NavMeshAgent.autoBraking = false;
        
        isShooting = false;
        shouldShoot = false;
        shootConroutine = ShootingCooldown(ShootCooldownInSeconds);
    }

    
    void Update()
    {
        if (!isShooting && shouldShoot)
        {
            StartCoroutine(shootConroutine);
            EnemyWeapon.Shoot();
        }
        else if (Waypoints != null && !NavMeshAgent.pathPending && NavMeshAgent.remainingDistance < 0.5f)
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
        NavMeshAgent.destination = Waypoints[waypointIndex].position;
    }

    public void ShouldShootPlayer()
    {
        shouldShoot = true;
    }
    
    public void ShouldNotShootPlayer()
    {
        shouldShoot = false;
    }

    private IEnumerator ShootingCooldown(float cooldown)
    {
        isShooting = true;
        NavMeshAgent.Stop();
        yield return new WaitForSeconds(cooldown);
        NavMeshAgent.Resume();
        isShooting = false;
    }
}
