using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class LaserLight : BaseInteractable
{
    public GameManager GameManager;
    public bool isActivated;
    public GameObject[] objecttodisable;
    public MeshRenderer[] objectMeshes;
    public Collider[] objectColliders;

    private void Start()
    {
        objectColliders = new Collider[objectColliders.Length];
        objectMeshes = new MeshRenderer[objectMeshes.Length];
        
        for (int i = 0; i < objecttodisable.Length; i++)
        {
            objectColliders[i] = objecttodisable[i].GetComponent<Collider>();
            objectMeshes[i] = objecttodisable[i].GetComponent<MeshRenderer>();
        }
        isActivated = false;
        /*_object.GetComponent<Collider>().enabled = true;
        mesh.enabled = true;*/
        Collider collider = GetComponent<Collider>();
        collider.isTrigger = true;
        StartCoroutine(OnOffLaser());
    }

    public override void Interact()
    {
        //StartCoroutine(OnOffLaser());
        //CheckforLaser();
    }
    /*private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<FirstPersonMovement>() != null)
        {
            CheckforLaser();
            StartCoroutine(OnOffLaser());
        }
    }*/

    public void CheckforLaser()
    {
        if (isActivated)
        {
            ActivateLaser();
        }
        else
        {
            DeActivateLaser();
        }
        
    }

    private void DeActivateLaser()
    {
        isActivated = false;
        for (int i = 0; i < objecttodisable.Length; i++)
        {
            if (objectMeshes != null)
            {
                objectMeshes[i].enabled = false;
            }
            if (objectColliders != null)
            {
                objectColliders[i].enabled = false;
            }
        }
        
/*      objectColliders.GetComponent<Collider>().enabled = false;
        objectMeshes.enabled = false;*/
    }

    private IEnumerator OnOffLaser()
    {
        while (true)
        {
            DeActivateLaser();
            yield return new WaitForSeconds(5f);
            ActivateLaser();
            yield return new WaitForSeconds(10f);
        }
    }

    public void ActivateLaser()
    {
        isActivated = true;
        for (int i = 0; i < objecttodisable.Length; i++)
        {
            
            if (objectMeshes != null)
            {
                objectMeshes[i].enabled = true;
            }
            if(objectColliders != null)
            {
                objectColliders[i].enabled = true;
            }
        }
        

        /*        objectColliders[i].GetComponent<Collider>().enabled = true;
                objectMeshes.enabled = true;*/
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<FirstPersonMovement>() != null && isActivated)
        {
            GameManager = FindObjectOfType<GameManager>();
            GameManager.FailLevel();
        }
    }
}
