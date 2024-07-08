using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordPuzzle : Puzzle
{
    public List<WordPuzzleData> availablePuzzles;
    public Button buttonTemplate;
    public Text finaltext;

    public int ButtonPressed;

    public List<Button> spawnedbuttn = new List<Button>();
    public WordPuzzleData currentPuzzle;

    public override void StartPuzzle()
    {
        gameObject.SetActive(true);

        int randomPuzzleIndex = UnityEngine.Random.Range(0, availablePuzzles.Count);
        currentPuzzle = availablePuzzles[randomPuzzleIndex];

        ButtonPressed = 0;
        finaltext.text = "";
        Shuffle(currentPuzzle.AvailableCharacters);

        buttonTemplate.gameObject.SetActive(false);
        spawnedbuttn = new List<Button>();
        for (int i = 0; i < currentPuzzle.AvailableCharacters.Count; i++)
        {
            int j = i;
            Button TempButton = Instantiate(buttonTemplate, buttonTemplate.transform.parent);
            TempButton.GetComponentInChildren<Text>().text = currentPuzzle.AvailableCharacters[i].ToString();
            TempButton.gameObject.SetActive(true);
            spawnedbuttn.Add(TempButton);
            TempButton.onClick.AddListener(() =>
            {
                finaltext.text += currentPuzzle.AvailableCharacters[j].ToString();
                TempButton.interactable = false;
                ButtonPressed++;

                if (finaltext.text == currentPuzzle.FinalWord)
                {
                    Debug.Log("User solved the puzzle.");
                    OnSuccessEvent.Invoke();
                    EndPuzzle();
                }
                else
                {
                    if (ButtonPressed == currentPuzzle.AvailableCharacters.Count)
                    {
                        Debug.Log("Puzzle Failed.");
                        OnFailEvent.Invoke();
                        EndPuzzle();
                    }
                }
            });

        }
    }
    public override void EndPuzzle()
    {
        for (int i = 0; i < spawnedbuttn.Count; i++)
        {
            Destroy(spawnedbuttn[i].gameObject);
        }
        gameObject.SetActive(false);
        spawnedbuttn.Clear();
    }

    private System.Random rng = new System.Random();

    public void Shuffle<T>(IList<T> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }

}

[System.Serializable]
public class WordPuzzleData
{
    public string FinalWord;
    public List<Char> AvailableCharacters;
}