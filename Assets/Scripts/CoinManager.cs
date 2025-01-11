using System;
using UnityEngine;
using UnityEngine.Events;

public class CoinManager : MonoBehaviour
{
    [SerializeField] Coin[] coins; // Any amount of coins can be added
    public UnityAction<int> OnCoinPickedUp; //This is The manager's action, different from the coin's one

    private void Start()
    {
        foreach (Coin coin in coins)
        {                    //Accesses every coin and ands to its action a function that invokes the manager's action
            coin.OnCoinPickUp += (coinPointValue) => OnCoinPickedUp?.Invoke(coinPointValue);
        }
    }
}
