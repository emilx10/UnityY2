using UnityEngine;
using UnityEngine.Events;

public class TakeDamage : MonoBehaviour
{
    public PlayerHealthManager playerHP;

    void Start()
    {
        if (playerHP != null)
        {
            playerHP.onHealthChanged.AddListener(playerHP.onHealthChanged.Invoke);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && playerHP != null)
        {
            playerHP.health -= 10;
            playerHP.onHealthChanged.Invoke();
        }
    }
}
