using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Coin : MonoBehaviour
{
    public UnityAction<int> OnCoinPickUp; //This is The coin's action, different from the manager's one
    [SerializeField] private int _pointValue;

    private void OnTriggerEnter(Collider other)
    {
        OnCoinPickUp?.Invoke(_pointValue);
        Destroy(gameObject);
    }
}
