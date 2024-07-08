using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public List<InventoryItems> inventoryItems = new List<InventoryItems>();
    public GameObject inventoryPanel;
    public GameObject ItemTemplate;
    public GameObject ItemImage;
    public bool isInventoryOpen = false;
    public List<GameObject> spawnedInventoryItems = new List<GameObject>();

    private void Start()
    {
        inventoryPanel.SetActive(false);
        ItemTemplate.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ToggleInventory();
        }
    }

    public void ToggleInventory()
    {
        if (isInventoryOpen)
        {
            CLoseInventory();
        }
        else
        {
            OpenInventory();
        }
    }

    public void OpenInventory()
    {
        inventoryPanel.gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        isInventoryOpen = true;
        Time.timeScale = 0;
        updateInventoryUI();

    }

    public void CLoseInventory()
    {
        inventoryPanel.gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        isInventoryOpen = false;
        Time.timeScale = 1;
    }

    private void updateInventoryUI()
    {
        for (int i = 0; i < spawnedInventoryItems.Count; i++)
        {
            Destroy(spawnedInventoryItems[i]); 
        }
        spawnedInventoryItems.Clear();

        for (int i = 0; i < inventoryItems.Count; i++)
        {

            GameObject spawnedtemplate = Instantiate(ItemTemplate, ItemTemplate.transform.parent);
            Text spawnedTemplateText = spawnedtemplate.GetComponentInChildren<Text>();
            spawnedTemplateText.text = inventoryItems[i].ItemName;
            Image spawnedImage = spawnedtemplate.gameObject.transform.Find("Item-Image").GetComponentInChildren<Image>();
            spawnedImage.sprite = inventoryItems[i].itemImage;
            spawnedtemplate.SetActive(true);
            spawnedInventoryItems.Add(spawnedtemplate);

        }
    }

    public void AddItems(InventoryItems addtoitem)
    {
        inventoryItems.Add(addtoitem);
    }

    public void RemoveItem(InventoryItems removetoitem)
    {
        if (inventoryItems.Contains(removetoitem))
        {
            inventoryItems.Remove(removetoitem);
        }

    }
    public bool HasItem(string itemName)
    {
        for (int i = 0; i < inventoryItems.Count; i++)
        {
            if(inventoryItems[i].ItemName == itemName)
            {
                return true;
            }   
        }
        return false;
    }
}
