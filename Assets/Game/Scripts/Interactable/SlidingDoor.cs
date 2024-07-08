using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : BaseInteractable
{

    public Vector3 OpenPosition = new Vector3();
    public Vector3 ClosePosition = new Vector3();
    public bool isOpen = false;
    public float speed = 5f;

    public event System.Action onDoorOpen;
    public event System.Action onDoorClose;

    private void Start()
    {
        CloseDoor();
    }
    public override void Interact()
    {
        ToggleDoor();
    }
    public void ToggleDoor()
    {
        if (isOpen)
        {
            CloseDoor();
            InfoText = "Press E to Open the Door";
        }
        else
        {
            InfoText = "Press E to Close the Door";
            OpenDoor();
        }

    }

    public void OpenDoor()
    {
        isOpen = true;
        onDoorOpen?.Invoke();
        StartCoroutine(MoveDoorToRequiredPosition());

    }
    public void CloseDoor()
    {
        isOpen = false;
        onDoorClose?.Invoke();
        StartCoroutine(MoveDoorToRequiredPosition());
    }

    IEnumerator MoveDoorToRequiredPosition()
    {
        Vector3 RequiredPosition = isOpen ? OpenPosition : ClosePosition;

        while (transform.localPosition != RequiredPosition)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, RequiredPosition, speed * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
    }

}
