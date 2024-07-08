using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSix : MonoBehaviour
{
    public GameManager gm;
    public WordPuzzle[] puzzles;
    public Transform completionPoint;
    public float completionRadius = 1f;
    public GameObject player;
    private int puzzlesSolved = 0;
    private bool isLevelCompleted = false;

    private void Start()
    {
        for (int i = 0; i < puzzles.Length; i++)
        {
            puzzles[i].OnSuccessEvent.AddListener(OnPuzzleSolved);
        }
    }
    private void Update()
    {
        // Continuously check the player's distance to the completion point if all puzzles are solved
        if (!isLevelCompleted && puzzlesSolved == puzzles.Length)
        {
            CheckLevelCompletion();
        }
    }

    private void OnPuzzleSolved()
    {
        puzzlesSolved++;
        CheckLevelCompletion();
    }

    private void CheckLevelCompletion()
    {
        float distanceToCompletion = Vector3.Distance(completionPoint.position, player.transform.position);
        //Debug.Log($"Puzzles Solved: {puzzlesSolved}/{puzzles.Length}, Distance to Completion: {distanceToCompletion}");
        if (puzzlesSolved == puzzles.Length && distanceToCompletion <= completionRadius)
        {
            CompleteLevel();
        }
    }

    private void CompleteLevel()
    {
        isLevelCompleted = true;
        Debug.LogError("Level Succeeded");
        gm.WinLevel();
    }
}
