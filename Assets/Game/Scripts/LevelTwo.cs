using UnityEngine;

public class LevelTwoPuzzlesCompletion : MonoBehaviour
{
    public GameManager gm;
    public WordPuzzle[] puzzles;
    public GameObject player;

    private int puzzlesSolved = 0;

    private void Start()
    {
        for (int i = 0; i < puzzles.Length; i++)
        {
            puzzles[i].OnSuccessEvent.AddListener(OnPuzzleSolved);
        }
    }

    private void OnPuzzleSolved()
    {
        puzzlesSolved++;
        CheckLevelCompletion();
    }

    private void CheckLevelCompletion()
    {
        if (puzzlesSolved == puzzles.Length)
        {
            Debug.LogError("Level Succeeded");
            gm.WinLevel();
            
        }
    }
}
