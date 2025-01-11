using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
public class ScoreText : MonoBehaviour
{
    [SerializeField] CoinManager coinManager; // The thing that handles the coins and the times they are picked up
    [SerializeField] private Text scoreText;
    
    private int score;
    private void Start()
    {
        score = 0;
        UpdateScoreText();
        coinManager.OnCoinPickedUp += AddToScore;
    }

    private void AddToScore(int addition)
    {
        score += addition;
        UpdateScoreText();
    }
    private void UpdateScoreText()
    {
        scoreText.text = score.ToString();
    }
}
