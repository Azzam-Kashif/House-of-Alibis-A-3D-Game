using System;
using UnityEngine;

public class LevelThree : MonoBehaviour
{
    public GameManager gm;
    public Coin[] coinsToCollect;
    public bool isLevelcomplete = false;
    public Transform completionPoint;
    public float completionRadius = 1f;
    public GameObject player;
    public Evidence[] collectiblesToCollect;
    bool allCoinsCollected = true;


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
        if (!isLevelcomplete && CheckAllCollectiblesCollected() && Vector3.Distance(completionPoint.position, player.transform.position) <= completionRadius)
        {
            CheckLevelCompletion();
        }
    }

    private void OnCoinCollect()
    {
        Debug.Log("Coin Collected!!");
        CheckLevelCompletion();
    }
    private bool CheckAllCollectiblesCollected()
    {
        // Check if all collectibles have been collected
        for (int i = 0; i < collectiblesToCollect.Length; i++)
        {
            if (collectiblesToCollect[i] != null) // Check if the collectible is not destroyed
            {
                return false;
            }
        }
        return true;
    }
    private void CheckLevelCompletion()
    {
        allCoinsCollected = true;
        for (int i = 0; i < coinsToCollect.Length; i++)
        {
            if (coinsToCollect[i] != null && !coinsToCollect[i].isCollected)
            {
                allCoinsCollected = false;
                Debug.Log(coinsToCollect[i].gameObject.name, coinsToCollect[i]);
                break;
            }
        }

        if (allCoinsCollected)
        {
            CompleteLevel();
        }
        else
        {
            Debug.Log("Not all coins collected");
        }
    }
    private void CompleteLevel()
    {
        // Load the next level
        isLevelcomplete = true;
        Debug.LogError("Level Finished");
        gm.WinLevel();
    }
}