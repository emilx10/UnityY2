using UnityEngine;

public class PlayerShootDetection : MonoBehaviour
{
    [SerializeField] private EnemyManager enemyManager;
    
    private void OnTriggerEnter(Collider other)
    {
        enemyManager.ShouldShootPlayer();
    }

    private void OnTriggerExit(Collider other)
    {
        enemyManager.ShouldNotShootPlayer();
    }
}
