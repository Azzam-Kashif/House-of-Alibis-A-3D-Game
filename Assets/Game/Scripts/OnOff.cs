using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnOff : MonoBehaviour
{
    public GameObject objectToAutomate;
    public MeshRenderer mesh;
    public int onDurationInSeconds;
    public int offDurationInSeconds;

    private void Start()
    {
        objectToAutomate.GetComponent<Collider>().enabled = true;
        mesh.enabled = true;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(AutoOnOffCoroutine());
        }
    }

    private IEnumerator AutoOnOffCoroutine()
    {
        while (true)
        {
            objectToAutomate.GetComponent<Collider>().enabled = true;
            mesh.enabled = true;
            yield return new WaitForSeconds(onDurationInSeconds);
            objectToAutomate.GetComponent<Collider>().enabled = false;
            mesh.enabled = false;
            yield return new WaitForSeconds(offDurationInSeconds);
        }
    }
}