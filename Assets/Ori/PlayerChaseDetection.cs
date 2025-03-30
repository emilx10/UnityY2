using UnityEngine;

public class PlayerChaseDetection : MonoBehaviour
{
    [SerializeField] private EnemyManager enemyManager;
    
    private void OnTriggerEnter(Collider other)
    {
        enemyManager.ChasePlayer();
    }

    private void OnTriggerExit(Collider other)
    {
        enemyManager.StopChasePlayer();
    }
}
