using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockedDoor : BaseInteractable
{
    public Vector3 OpenRotation = new Vector3();
    public Vector3 CloseRotation = new Vector3();
    public string KeyName = "Door_Key_1";
    public bool RequireKey = false;
    public bool isOpen = false;
    public bool isLocked = false;
    public float speed = 200f;
    public event System.Action onDoorOpen;
    public event System.Action onDoorClose;
    private Quaternion targetrotation;
    public Text LockedText;
    private bool isTextShowing;
    //public Animator DoorAnimation;

    private void Start()
    {
        speed = 5f;
        LockedText.gameObject.SetActive(false);
        CloseDoor();
        if (RequireKey)
        {
            isLocked = true;
        }
        else
        {
            isLocked = false;
        }
    }
    public override void Interact()
    {
        ToggleDoor();
    }
    public void ToggleDoor()
    {
        TryUnlock();
        if (isLocked)
        {
            if (!isTextShowing)
            {
                StartCoroutine(ShowLockedText());
            }
        }
        else if (isOpen)
        {

            CloseDoor();
            InfoText = "Press E to Open the Door";
            LockedText.gameObject.SetActive(false);

        }
        else
        {
            InfoText = "Press E to Close the Door";
            OpenDoor();
            LockedText.gameObject.SetActive(false);
        }
    }

    public void OpenDoor()
    {
        if (isLocked)
        {
            TryUnlock();
        }
        if (!isLocked)
        {
            isOpen = true;
            onDoorOpen?.Invoke();
            transform.localRotation = Quaternion.Euler(OpenRotation);
            //DoorAnimation.SetBool("Opening", true);
            //StartCoroutine(AnimateDoor(OpenRotation));
        }
        else
        {
            Debug.Log("Door is Locked.");
        }
    }
    public void CloseDoor()
    {
        isOpen = false;
        onDoorClose?.Invoke();
        transform.localRotation = Quaternion.Euler(CloseRotation);
        //DoorAnimation.SetBool("Opening", false);
        //StartCoroutine(AnimateDoor(CloseRotation));
    }
    private void TryUnlock()
    {
        Inventory inventory = FindAnyObjectByType<Inventory>();
        if (inventory.HasItem(KeyName))
        {
            isLocked = false;
        }
    }
    private IEnumerator ShowLockedText()
    {
        isTextShowing = true;
        LockedText.gameObject.SetActive(true); // Show the locked text
        yield return new WaitForSeconds(1f); // Wait for 2 seconds
        LockedText.gameObject.SetActive(false); // Hide the locked text
        isTextShowing = false;
    }

}
