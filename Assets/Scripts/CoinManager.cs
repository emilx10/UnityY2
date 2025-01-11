using System;
using UnityEngine;
using UnityEngine.Events;

public class CoinManager : MonoBehaviour
{
    [SerializeField] Coin[] coins;
    public UnityAction<int> OnCoinPickedUp;

    private void Start()
    {
        foreach (Coin coin in coins)
        {                    //Accesses every coin and ands to its action a function that invokes the manager's action
            coin.OnCoinPickUp += (coinPointValue) => OnCoinPickedUp?.Invoke(coinPointValue);
        }
    }
}
