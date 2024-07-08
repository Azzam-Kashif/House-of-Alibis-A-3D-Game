using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : BaseInteractable
{
    public Light lights;
    public bool ison = true;
    public string LightKey = "LightSwitch";

    // Start is called before the first frame update

    private void Start()
    {

        if (PlayerPrefs.GetInt(LightKey) == 1)
        {
            TurnOn();
        }
        else
        {
            TurnOff();
        }
    }



    public override void Interact()
    {
        if (ison)
        {
            PlayerPrefs.SetInt(LightKey, 0);
            TurnOff();

        }
        else
        {
            PlayerPrefs.SetInt(LightKey, 1);
            TurnOn();

        }

    }
    public void TurnOn()
    {
        lights.enabled = true;
        ison = true;

    }
    public void TurnOff()
    {
        lights.enabled = false;
        ison = false;

    }
}

