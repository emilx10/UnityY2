using UnityEngine;

public class EnemyTrackerHelper : MonoBehaviour
{
    private bool wasActive = true;

    void Start()
    {
        EnemyTracker.Instance?.RegisterEnemy(gameObject);
    }

    void Update()
    {
        if (wasActive && !gameObject.activeInHierarchy)
        {
            wasActive = false;
            EnemyTracker.Instance?.EnemyDied(gameObject);
        }
    }
}