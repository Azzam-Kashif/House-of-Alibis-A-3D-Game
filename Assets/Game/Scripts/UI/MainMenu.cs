using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class MainMenu : MonoBehaviour
{
  
    public Button PlayButton;
    public Button SettingsButton;
    public Button CloseSettingsButton;
    public Button closeLevelSelectionButton;
    public Button OpenShopButton;
    public Button CloseShopButton;

    public Button QuitButton;


    public GameObject settingPanel;
    public GameObject mainmenuPanel;
    public GameObject levelselectionpanel;
    public GameObject shopPanel;

    // Start is called before the first frame update
    void Start()
    {
        levelselectionpanel.SetActive(false);
        settingPanel.SetActive(false);
        mainmenuPanel.SetActive(true);

        PlayButton.onClick.AddListener(OpenLevelSelection);
        SettingsButton.onClick.AddListener(OpenSetting);
        closeLevelSelectionButton.onClick.AddListener(CloseLevelSelectin);
        CloseSettingsButton.onClick.AddListener(CloseSetting);
        QuitButton.onClick.AddListener(QuitGame);

        OpenShopButton.onClick.AddListener(OpenShop);
        CloseShopButton.onClick.AddListener(CloseShop);
    }

    private void CloseShop()
    {
        mainmenuPanel.SetActive(true);
        shopPanel.SetActive(false);
    }

    private void OpenShop()
    {
        mainmenuPanel.SetActive(false);
        shopPanel.SetActive(true);
    }

    private void CloseLevelSelectin()
    {
        levelselectionpanel.SetActive(false);
        mainmenuPanel.SetActive(true);
    }

    private void OpenLevelSelection()
    {
        levelselectionpanel.SetActive(true);
        mainmenuPanel.SetActive(false);
    }

    

    public void OpenSetting()
    {
        mainmenuPanel.SetActive(false);
        settingPanel.SetActive(true);
    }

    public void CloseSetting()
    {
        mainmenuPanel.SetActive(true);
        settingPanel.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();   
    }
}
