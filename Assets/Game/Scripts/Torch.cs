using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Torch : MonoBehaviour
{
    public bool isFlashlightOn = false;
    public GameObject flashlightModel;
    public Text purchaseText;
    public Text turnOnText;

    void Start()
    {
        // Assuming the flashlight model is a child of the GameObject this script is attached to
        flashlightModel = transform.Find("Flashlight").gameObject;
        ToggleFlashlight(false); // Start with the flashlight off

        UpdateText(); // Initialize text visibility correctly
    }

    void Update()
    {
        bool isPurchased = PlayerPrefs.GetInt("Torch", 0) == 1;

        if (!isPurchased)
        {
            purchaseText.gameObject.SetActive(true);
            purchaseText.text = "In the darkest hour, the path is clear, With the light, the truth is near.";
            return; // Exit the Update method
        }

        // Check if the "T" key is pressed
        if (Input.GetKeyDown(KeyCode.T))
        {
            isFlashlightOn = !isFlashlightOn;
            ToggleFlashlight(isFlashlightOn);
            UpdateText(); // Update text visibility when toggling the flashlight
        }
        UpdateText();
    }

    void ToggleFlashlight(bool on)
    {
        // Toggle the visibility of the flashlight model based on the 'on' parameter
        flashlightModel.SetActive(on);
    }

    void UpdateText()
    {
        bool isPurchased = PlayerPrefs.GetInt("Torch", 0) == 1;
        bool isGamePaused = Time.timeScale == 0;

        if (isGamePaused)
        {
            turnOnText.gameObject.SetActive(false);
            purchaseText.gameObject.SetActive(false);
            return;
        }
        if (isPurchased)
        {
            if (isFlashlightOn)
            {
                turnOnText.gameObject.SetActive(false);
                turnOnText.text = "";
            }
            else
            {
                turnOnText.gameObject.SetActive(true);
                turnOnText.text = "Press T to Turn On Torch";
            }
            purchaseText.gameObject.SetActive(false);
        }
        else
        {
            turnOnText.gameObject.SetActive(false);
            purchaseText.gameObject.SetActive(true);
            purchaseText.text = "In the darkest hour, the path is clear, With the light, the truth is near.";
        }
    }
}
