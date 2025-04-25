using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayerHealthScript : MonoBehaviour
{
    public UnityAction<int> OnHPChange; //right now the only listener is HealthText, the rest of the logic is here

    private int health;

    public Animator anim;

    private void Start()
    {
        health = 100;
    }

    private void OnTriggerEnter(Collider other) // Can add here more tags for different things that deal damage
    {
        if (other.CompareTag("Laser"))
        {
            TakeDamage(10);
        }
    }
    private void TakeDamage(int damage) // General damage function, calls for the HPChange UnityAction
    {
        health -= damage;
        anim.SetTrigger("Hit");
        OnHPChange?.Invoke(health);
    }
}