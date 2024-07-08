using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dark : MonoBehaviour
{
    /*[SerializeField]
    public Color ambientLightColor = Color.black;
    public Material darkSkyboxMaterial;*/
    public Color skyColor = Color.black;
    public Light directionalLight;
    void Start()
    {
        directionalLight.transform.rotation = Quaternion.Euler(220, 0, 0);

        RenderSettings.ambientMode = UnityEngine.Rendering.AmbientMode.Trilight;

    
        RenderSettings.ambientLight = skyColor;
     
        Light[] lights = FindObjectsOfType<Light>();
        foreach (Light light in lights)
        {
            light.enabled = false;
        }
        
    }
    /* void Start()
     {
         // Remove the skybox
         RenderSettings.skybox = darkSkyboxMaterial;

         // Disable all lights in the scene
         foreach (var light in FindObjectsOfType<Light>())
         {
             light.enabled = false;
         }

         // Apply a solid black color to the ambient light
         RenderSettings.ambientLight = Color.black;
     }*/

}