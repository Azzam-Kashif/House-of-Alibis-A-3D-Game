using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InteractableInventoryItem : BaseInteractable
{
    
    public InventoryItems Item;
    public override void Interact()
    {
        Debug.Log("interacted with inventory interactable");
        Inventory inventory = FindObjectOfType<Inventory>();
        if(inventory != null)
        {
            inventory.AddItems(Item);
            Destroy(gameObject);
        }
    }
}
