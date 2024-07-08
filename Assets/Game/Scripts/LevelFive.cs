using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelFive : MonoBehaviour
{
    public GameManager gm;
    public List<Coin> coinsToCollect;
    public GameObject player;
    public bool isLevelCompleted = false;

    private void Start()
    {
        foreach (var coin in coinsToCollect)
        {
            coin.onCoinCollect += OnCoinCollect;
        }
    }

    private void Update()
    {
        if (isLevelCompleted || player == null)
        {
            return;
        }

        if (CheckLevelCompletion())
        {
            CompleteLevel();
        }
    }

    private void OnCoinCollect()
    {
        if (CheckLevelCompletion())
        {
            CompleteLevel();
        }
    }

    private bool CheckLevelCompletion()
    {
        foreach (var coin in coinsToCollect)
        {
            if (!coin.isCollected)
            {
                return false;
            }
        }

        return true;
    }

    private void CompleteLevel()
    {
        isLevelCompleted = true;
        Debug.Log("Level Finished");
        gm.WinLevel();
    }
}
