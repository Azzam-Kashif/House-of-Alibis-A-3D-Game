using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CriticalWalls : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        FirstPersonMovement firstPersonMovement = other.GetComponent<FirstPersonMovement>();
        
        if(firstPersonMovement != null)
        {
            // Activate Alarm 
        }
    }
}
