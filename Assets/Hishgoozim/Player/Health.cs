using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float maxHP = 100;
    private float currentHP;

    private void Awake()
    {
        currentHP = maxHP;
    }

    public float TakeDamage(float amount)
    {
        currentHP -= amount;
        if (currentHP <= 0) Kill();
        
        return currentHP;
    }

    void Kill()
    {
        // Do kill logic
    }
}
