using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Collider))]
public class BaseInteractable : MonoBehaviour
{
    public string InfoText = "Please Configure Text through inspector";
   public virtual void Interact()
    {
        Debug.Log("Interacted with Base Interactable");
    }
    
}
