using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSeven : MonoBehaviour
{
    public Transform completionPoint; // The point where the player needs to reach to complete the level
    public GameObject player;
    public float completionRadius = 1f; // The radius around the completion point within which the player needs to be to complete the level
    public Evidence[] collectiblesToCollect; // Array of all collectibles in the level
    private bool isLevelCompleted = false;
    public GameManager gm;

    private void Update()
    {
        // Check if all collectibles have been collected
        if (!isLevelCompleted && CheckAllCollectiblesCollected() && Vector3.Distance(completionPoint.position, player.transform.position) <= completionRadius)
        {
            CompleteLevel();
        }
    }

    private bool CheckAllCollectiblesCollected()
    {
        // Check if all collectibles have been collected
        for (int i = 0; i < collectiblesToCollect.Length; i++)
        {
            if (collectiblesToCollect[i] != null) // Check if the collectible is not destroyed
            {
                Debug.Log("Evidences collected");
                return false;
            }
        }
        return true;
    }

    private void CompleteLevel()
    {
        // Set the level as completed
        isLevelCompleted = true;
        Debug.Log("Level completed");
        gm.LastLevel();
        // Load the next level or show level completion screen
    }
}
