using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleDoor : BaseInteractable
{
    public Vector3 OpenRotation = new Vector3();
    public Vector3 CloseRotation = new Vector3();
    public Puzzle Puzzle;
    public bool isOpen = false;
    public FirstPersonMovement player;



    private void Start()
    {
        CloseDoor();
        player = FindAnyObjectByType<FirstPersonMovement>();
        Puzzle.OnSuccessEvent.AddListener(OnPuzzleSucceded);
        Puzzle.OnFailEvent.AddListener(OnPuzzleFailed);
    }

    public override void Interact()
    {
        if (isOpen)
        {
            return;
        }
        Puzzle.StartPuzzle();
        player.gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void ToggleDoor()
    {
        if (isOpen)
        {
            CloseDoor();
        }
        else
        {
            OpenDoor();
        }

    }
    private void OnPuzzleSucceded()
    {
        OpenDoor();
        GameManager gm = FindObjectOfType<GameManager>();
        if (gm != null && gm.isPopupActive)
        {
            return;  // Don't activate player if the level is completed
        }
        player.gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Destroy(this);
    }

    private void OnPuzzleFailed()
    {
        player.gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public void OpenDoor()
    {
            isOpen = true;
            transform.localRotation = Quaternion.Euler(OpenRotation); 
    }
    public void CloseDoor()
    {
        isOpen = false;
        transform.localRotation = Quaternion.Euler(CloseRotation);
    }
}
 