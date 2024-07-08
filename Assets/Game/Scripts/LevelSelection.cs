using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LevelSelection : MonoBehaviour
{
    public string SceneName;
    public List<Button> levelbuttons;

    private void Start()
    {
        for (int i = 0; i < levelbuttons.Count; i++)
        {
            int j = i;
            levelbuttons[j].onClick.AddListener(() =>
            {
                UserData.SetSelectedLevel(j);
                if (UserData.GetSelectedLevel() == 4)
                {
                    SceneManager.LoadScene("Night Scene"); // Load the night scene for level 5
                }
                else
                {
                    SceneManager.LoadScene(SceneName);// Load the next level (normal scene)
                }


            });
        }
        int maxLevel = UserData.CurrentLevel();
        for (int i = 0; i < levelbuttons.Count; i++)
        {
            if (i <= maxLevel)
            {
                levelbuttons[i].interactable = true;
            }
            else
            {
                levelbuttons[i].interactable = false;
            }

        }
    }
}
