using UnityEngine;

public class LevelOne : MonoBehaviour
{
    public GameManager gm;
    public LockedDoor[] doorToUnlock;
    public Coin[] coinsToCollect;
    private bool allDoorsOpened = false;
    bool allCoinsCollected = false;

    private void Start()
    {
        for (int i = 0; i < doorToUnlock.Length; i++)
        {
            doorToUnlock[i].onDoorOpen += OnDoorOpen;

        }

        for (int i = 0; i < coinsToCollect.Length; i++)
        {
            coinsToCollect[i].onCoinCollect += OnCoinCollect;
        }
    }
    private void Update()
    {
        CheckLevelCompletion();
    }

    private void OnDoorOpen()
    {
        CheckLevelCompletion();
    }

    private void OnCoinCollect()
    {
        CheckLevelCompletion();
    }

    private void CheckLevelCompletion()
    {
        allDoorsOpened = true;
        for (int i = 0; i < doorToUnlock.Length; i++)
        {
            if (!doorToUnlock[i].isOpen)
            {
                allDoorsOpened = false;
                Debug.Log($"Door {i} is not open.");
                break;
            }
            else
            {
                Debug.Log($"Door {i} is open.");
            }
        }

        allCoinsCollected = true;
        for (int i = 0; i < coinsToCollect.Length; i++)
        {
            if (!coinsToCollect[i].isCollected)
            {
                allCoinsCollected = false;
                Debug.Log($"Coin {i} is not collected.");
                break;
            }
            else
            {
                Debug.Log($"Coin {i} is Collected.");
            }
        }

        if (allDoorsOpened && allCoinsCollected)
        {
          
            Debug.LogError("Level Succeeded");
            gm.WinLevel();
            
        }
    }
}
