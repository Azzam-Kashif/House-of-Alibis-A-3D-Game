using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;


public class Puzzle : MonoBehaviour
{
    public UnityEvent OnSuccessEvent = new UnityEvent();
    public UnityEvent OnFailEvent = new UnityEvent();
  


    public virtual void StartPuzzle()
    {
        Debug.Log("Puzzle Started");
    }
    public virtual void EndPuzzle()
    {
        Debug.Log("Puzzle Ended");
    }

}

