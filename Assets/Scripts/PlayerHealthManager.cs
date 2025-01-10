using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayerHealthManager : MonoBehaviour
{
    public UnityEvent onHealthChanged;
    public Text textHealth;
    public int health = 100;

    void Start()
    {
        if (onHealthChanged == null)
        {
            onHealthChanged = new UnityEvent();
        }

        UnityAction updateHealthTextAction = UpdateHealthText;
        onHealthChanged.AddListener(updateHealthTextAction);

        UpdateHealthText();
    }

    public void UpdateHealthText()
    {
        textHealth.text = health.ToString();
    }
}
