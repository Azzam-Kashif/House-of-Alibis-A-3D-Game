using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFour : MonoBehaviour
{
    public GameManager gm;
    public Coin[] coinsToCollect;
    public Transform completionPoint;
    public float completionRadius = 1f;
    public GameObject player;
    private bool isLevelCompleted = false;

    private void Start()
    {
        for (int i = 0; i < coinsToCollect.Length; i++)
        {
            coinsToCollect[i].onCoinCollect += OnCoinCollect;
        }
    }

    private void Update()
    {
        if (player == null)
        {
            Debug.Log("Assign");
        }
        // Check the distance between the player and the completion point
        if (!isLevelCompleted && Vector3.Distance(completionPoint.position, player.transform.position) <= completionRadius)
        {
            CheckLevelCompletion();
        }
    }

    private void OnCoinCollect()
    {
        CheckLevelCompletion();
    }

    private void CheckLevelCompletion()
    {
        bool allCoinsCollected = true;
        for (int i = 0; i < coinsToCollect.Length; i++)
        {
            if (!coinsToCollect[i].isCollected)
            {
                allCoinsCollected = false;
                break;
            }
        }

        if (allCoinsCollected && Vector3.Distance(completionPoint.position, player.transform.position) <= completionRadius)
        {
            CompleteLevel();
        }
    }

    private void CompleteLevel()
    {
        // Load the next level
        isLevelCompleted = true;
        Debug.LogError("Level Finished");
        gm.WinLevel();
    }
}