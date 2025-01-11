using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Coin : MonoBehaviour
{
    public UnityAction<int> OnCoinPickUp;
    [SerializeField] private int _pointValue;

    private void OnTriggerEnter(Collider other)
    {
        OnCoinPickUp?.Invoke(_pointValue);
        Destroy(gameObject);
    }
}
