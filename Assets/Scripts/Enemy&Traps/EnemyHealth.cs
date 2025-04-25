using System.Collections;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] GameObject enemy;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            anim.SetTrigger("dead");
            StartCoroutine(DeactivateEnemy());
        }
    }

    IEnumerator DeactivateEnemy()
    {
        yield return new WaitForSeconds(2f);
        enemy.SetActive(false);
    }
}
