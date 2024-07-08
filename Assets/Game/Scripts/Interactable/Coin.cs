using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int coinValue = 1;
    public string coinKey;
    public CoinManager coinScore;
    public event Action onCoinCollect;

    public bool isCollected { get; private set; }

    private void Start()
    {
        if (PlayerPrefs.GetInt(coinKey, 0) == 1)
        {
            Destroy(gameObject);
        }
        GetComponent<Collider>().isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        Collect();
        Destroy(gameObject);
    }

    private void Collect()
    {
        if (!isCollected)
        {
            int currentCoins = UserData.GetPlayerCoins();
            onCoinCollect?.Invoke();
            UserData.SetPlayerCoins(currentCoins + coinValue);

            coinScore.IncrementScore(coinValue);

            PlayerPrefs.SetInt(coinKey, 1);
            isCollected = true;
        }
    }
}
