using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Coin : MonoBehaviour
{
    public UnityAction OnCoinPickUp;

    private void OnTriggerEnter(Collider other)
    {
        OnCoinPickUp?.Invoke();
        Destroy(gameObject);
    }
}
