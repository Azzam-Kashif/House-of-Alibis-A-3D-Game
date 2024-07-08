using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public List<ShopItem> shopItems = new List<ShopItem>();
    public Button itemButtonTemplate;
    public Button PurchaseButton;
    public Image itemImage;
    public CoinManager coinManager;

    private void Start()
    {
        itemButtonTemplate.gameObject.SetActive(false);
        for(int i = 0; i < shopItems.Count; i++)
        {
            int j = i;
            Button tempButton = Instantiate(itemButtonTemplate, itemButtonTemplate.transform.parent);
            tempButton.gameObject.SetActive(true);

            tempButton.GetComponentInChildren<Text>().text = shopItems[i].Name;
            tempButton.transform.GetChild(1).GetComponent<Image>().sprite = shopItems[i].itemsprite;
            tempButton.onClick.AddListener(() => {
                SelectedItem(j);
            });
        }
        SelectedItem(0);

    }
    public void SelectedItem(int itemindex)
    {
        itemImage.sprite = shopItems[itemindex].itemsprite;
        PurchaseButton.onClick.RemoveAllListeners();

        if (PlayerPrefs.GetInt(shopItems[itemindex].ItemKey, 0) == 1)
        {
            PurchaseButton.GetComponentInChildren<Text>().text = "Already Purchased";
            PurchaseButton.interactable = false;
        }
        else
        {
            PurchaseButton.GetComponentInChildren<Text>().text = "Purchase";
            PurchaseButton.interactable = true;
            PurchaseButton.onClick.AddListener(() =>
            {
                PurchaseItem(itemindex);
            });
        }

    }

    public void PurchaseItem(int itemindex)
    {
        int coinsInInventory = UserData.GetPlayerCoins();
        int itemPrice = shopItems[itemindex].ItemPrice;

        if(coinsInInventory >= itemPrice)
        {
            coinsInInventory -= itemPrice;
            UserData.SetPlayerCoins(coinsInInventory);

            PlayerPrefs.SetInt(shopItems[itemindex].ItemKey , 1);
            SelectedItem(itemindex);

            coinManager.UpdateScoreText();
           
        }
        else
        {
            Debug.Log("You don't have enough coins");
        }
    }
    /*public void BuyGlasses()
    {
        if(UserData.GetPlayerCoins() >= 50)
        {
            int coinsPlayerHave = UserData.GetPlayerCoins();
            coinsPlayerHave -= 50;
            UserData.SetPlayerCoins(coinsPlayerHave);
            PlayerPrefs.SetInt("Glasses", 1); 
        }
        else
        {
            Debug.Log("You don't have enough coins");
        }
    }*/
}
[System.Serializable]
public class ShopItem {

    public string Name;
    public Sprite itemsprite;
    public int ItemPrice;
    public string ItemKey;

}
