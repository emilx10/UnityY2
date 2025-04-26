using UnityEngine;

public class BulletManager : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("player") && !other.CompareTag("BulletIgnore"))
        {
            Debug.Log(other.tag);
            Destroy(gameObject);
        }
    }
}
