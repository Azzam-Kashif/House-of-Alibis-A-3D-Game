using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseResume : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public Button ResumeButton;
    public Button MainMenuButton;
    public Button Exit;

    public GameObject instructiontext;

    private bool isPaused = false;
    private void Start()
    {
        pauseMenuUI.SetActive(false);
        ResumeButton.onClick.AddListener(ResumeGame);
        MainMenuButton.onClick.AddListener(ReturnToMainMenu);
        Exit.onClick.AddListener(ExitGame);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
        bool isEscapeMenuActive = pauseMenuUI.activeSelf;
        instructiontext.SetActive(!isEscapeMenuActive);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f; // Resume normal time scale
        pauseMenuUI.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false; 
        isPaused = false;
    }

    void PauseGame()
    {
        Time.timeScale = 0f; // Stop time
        pauseMenuUI.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        isPaused = true;
    }

    public void ReturnToMainMenu()
    {
        Time.timeScale = 1f; // Resume normal time scale
        SceneManager.LoadScene("MainMenu"); // Load the main menu scene
    }

    public void ExitGame()
    {
        Application.Quit(); // Quit the application (works in standalone builds)
    }
}
