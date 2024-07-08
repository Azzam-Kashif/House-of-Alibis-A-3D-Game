using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CoinManager : MonoBehaviour
{
    private int score = 0;
    public Text scoreText;

    private void Start()
    {
        // Initialize the score text
        UpdateScoreText();
    }

    public void UpdateScoreText()
    {
        // Update the score text to display the current score
        scoreText.text = "" + UserData.GetPlayerCoins().ToString();
    }

    public void IncrementScore(int amount)
    {
        // Increment the score by the specified amount
        score += amount;

        // Update the score text
        UpdateScoreText();
    }
}
