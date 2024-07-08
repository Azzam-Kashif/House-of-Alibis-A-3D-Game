using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Splash : MonoBehaviour
{
    public string SceneName;
    public Image loadingbar;
    public float loadTime;
    private float currentTime;
    AsyncOperation loadOperation;
 
    void Start()
    {
        loadOperation = SceneManager.LoadSceneAsync(SceneName);
        loadOperation.allowSceneActivation = false;
    }
    private void Update()
    {
        currentTime += Time.deltaTime;
        loadingbar.fillAmount = currentTime / loadTime;
        if(currentTime >= loadTime)
        {
            loadOperation.allowSceneActivation = true;
        }
    }

}
