using UnityEngine;

public class EnemyTrackerHelper : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        EnemyTracker.Instance?.RegisterEnemy(gameObject);

        Health health = GetComponent<Health>();
        if (health != null)
        {
            health.onDeath.AddListener(OnDeath);
        }
    }

    private void OnDeath()
    {
        EnemyTracker.Instance?.EnemyDied(gameObject);
    }
}
