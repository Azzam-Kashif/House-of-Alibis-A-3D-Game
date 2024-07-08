using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Text TimerText;
    public GameObject levelSuccessPopup;
    public GameObject levelFailPopup;
    public GameObject lastlevelPopup;
    public FirstPersonMovement player;
    public Button NextLevelButton;
    public Button MainMenuButton;
    public Button FMainMenuButton;
    public Button LastlevelMainMenuButton;
    public Button RestartButton;
    public Canvas puzzlecanvas;
    public Canvas canva;
    public List<level> levels = new List<level>();
    public bool isPopupActive = false;
    private int currentLevelIndex = 0;
    private LevelFive levelFiveScript;

    private void Start()
    {
        if (isPopupActive) return;
        levelSuccessPopup.SetActive(false);
        levelFailPopup.SetActive(false);
        lastlevelPopup.SetActive(false);
        NextLevelButton.onClick.AddListener(NextLevel);
        MainMenuButton.onClick.AddListener(MainMenu);
        FMainMenuButton.onClick.AddListener(MainMenu);
        LastlevelMainMenuButton.onClick.AddListener(MainMenu);
        RestartButton.onClick.AddListener(RestartLevel);
        int currentlevel = UserData.GetSelectedLevel();
        player.transform.position = levels[currentlevel].spawnpoint.position;
        levels[currentlevel].levelObject.gameObject.SetActive(true);


        if (levels[currentlevel].hasTimer)
        {
            TimerText.gameObject.SetActive(true);
            StartCoroutine(Timer());
        }
        else
        {
            TimerText.gameObject.SetActive(false);
        }

        if (currentlevel == 4)
        {
            levelFiveScript = FindObjectOfType<LevelFive>();
            if (levelFiveScript != null)
            {
                levelFiveScript.gm = this;
            }
        }
        if (isPopupActive)
        {
            isPopupActive = false;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            Time.timeScale = 1f;
        }
        if (FMainMenuButton != null)
        {
            FMainMenuButton.onClick.RemoveAllListeners();
            FMainMenuButton.onClick.AddListener(MainMenu);

        }

    }

    private IEnumerator Timer()
    {
        int levelIndex = UserData.GetSelectedLevel();
        float totaltime = levels[levelIndex].TotalTime;

        while (totaltime > 0 && !isPopupActive)
        {
            totaltime -= Time.deltaTime;
            TimerText.text = totaltime.ToString("#");
            yield return null;
        }

        if (!isPopupActive)
        {
            FailLevel();
        }
    }

    public void FailLevel()
    {
        isPopupActive = true;
        levelFailPopup.SetActive(true);
        HideUIElements();
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f;
    }

    public void WinLevel()
    {
        isPopupActive = true;
        Time.timeScale = 0f;
        levelSuccessPopup.SetActive(true);
        HideUIElements();
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        int currentLevel = UserData.CurrentLevel();
        Debug.Log(currentLevel);
        Debug.Log(UserData.GetSelectedLevel());
        if ((currentLevel < levels.Count - 1) && (UserData.GetSelectedLevel() == UserData.CurrentLevel()))
        {
            UserData.SetCurrentLevel(currentLevel + 1);
            
        }
        

    }

    public void LastLevel()
    {
        isPopupActive = true;
        lastlevelPopup.SetActive(true);
        HideUIElements();
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f;

        if (LastlevelMainMenuButton != null)
        {
            LastlevelMainMenuButton.onClick.RemoveAllListeners();
            LastlevelMainMenuButton.onClick.AddListener(MainMenu);
            Debug.Log("Listner added in buttn");
        }
    }

    public void NextLevel()
    {
        int currentLevel = UserData.GetSelectedLevel();
        if (currentLevel < levels.Count - 1)
        {
            currentLevel++;
            UserData.SetSelectedLevel(currentLevel); // Set next level as Selected Level
        }
        if (currentLevel == 4)
        {
            SceneManager.LoadScene("Night Scene"); // Load the night scene for level 5
        }
        else
        {
            SceneManager.LoadScene("Demo Scene");// Load the next level (normal scene)
        }

        Time.timeScale = 1f;

    }


    public void RestartLevel()
    {
        int currentLevelIndex = UserData.GetSelectedLevel();
        player.transform.position = levels[currentLevelIndex].spawnpoint.position;
        levelFailPopup.SetActive(false);
        Time.timeScale = 1f;
        isPopupActive = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        ShowUIElements();
        if (levels[currentLevelIndex].hasTimer)
        {
            StopCoroutine(Timer());
            StartCoroutine(Timer());
        }
    }

    public void MainMenu()
    {
        Debug.Log("MainMenu method called.");
        isPopupActive = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f;
        // Reset the selected level
        SceneManager.LoadScene("MainMenu");

        int selectedLevel = UserData.GetSelectedLevel();
        UserData.SetSelectedLevel(selectedLevel);
        levelSuccessPopup.SetActive(false);
        levelFailPopup.SetActive(false);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        player.transform.position = levels[selectedLevel].spawnpoint.position;
        if (levels[selectedLevel].hasTimer)
        {
            StopCoroutine(Timer());
            StartCoroutine(Timer());
        }
    }
    private void HideUIElements()
    {
        TimerText.gameObject.SetActive(false);
        if (canva != null)
        {
            canva.gameObject.SetActive(false);
        }
    }

    private void ShowUIElements()
    {
        int currentlevel = UserData.GetSelectedLevel();
        if (levels[currentlevel].hasTimer)
        {
            TimerText.gameObject.SetActive(true);
        }
        if (canva != null)
        {
            canva.gameObject.SetActive(true);
        }
    }
}
[System.Serializable]
public class level
{
    public Transform spawnpoint;
    public GameObject levelObject;
    public float TotalTime = 60f;
    public bool hasTimer = false;
}