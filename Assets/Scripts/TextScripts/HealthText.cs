using System;
using UnityEngine;
using UnityEngine.UI;

public class HealthText : MonoBehaviour
{
    [SerializeField] PlayerHealthScript playerHealthScript; // The respective player's HealthScript
    [SerializeField] private Text healthText;

    private void Start()
    {
        healthText.text = 100.ToString();
        playerHealthScript.OnHPChange += UpdateText; //HealthText does not communicate with the actual Health value in any way
    }
    
    private void UpdateText(int health)
    {
        healthText.text = health.ToString();
    }
}
