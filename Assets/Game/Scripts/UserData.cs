using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UserData
{
    public static void SetPlayerCoins(int amount)
    {
        PlayerPrefs.SetInt("PlayerCoins", amount);
    }
    public static int GetPlayerCoins()
    {
        return PlayerPrefs.GetInt("PlayerCoins");
    }

    public static void SetEvidence(string collectibleName, int number)
    {
        PlayerPrefs.SetInt("Evidence" + collectibleName, number);
    }
    public static int GetEvidence(string collectibleName)
    {
        return PlayerPrefs.GetInt("Evidence" + collectibleName);
    }

    public static void SetSelectedLevel(int level)
    {
        PlayerPrefs.SetInt("SelectedLevel", level);
    }

    public static int GetSelectedLevel()
    {
        return PlayerPrefs.GetInt("SelectedLevel", 0);
    }
    public static int CurrentLevel()
    {
        return PlayerPrefs.GetInt("CurrentLevel", 0);
    }
    public static void SetCurrentLevel(int level)
    {
        PlayerPrefs.SetInt("CurrentLevel", level);
    }
    public static void SetPurchasedItem(string key, bool value)
    {
        PlayerPrefs.SetInt(key, value ? 1 : 0);
    }
    public static bool GetPurchasedItem(string key)
    {
        return PlayerPrefs.GetInt(key, 0) == 1;
    }
}

