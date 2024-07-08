using UnityEngine;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{
    public Slider volumeSlider;

    private Sound soundManager;

    void Start()
    {
        soundManager = FindObjectOfType<Sound>();
        if (soundManager == null)
        {
            Debug.LogError("SoundManager not found in the scene.");
            return;
        }

        // Set the initial value of the slider to match the current volume
        volumeSlider.value = soundManager.Volume;
        // Add a listener to the slider to detect changes in volume
        volumeSlider.onValueChanged.AddListener(OnVolumeChanged);
    }

    void OnVolumeChanged(float volume)
    {
        // Update the volume in the SoundManager
        soundManager.SetVolume(volume);
    }
}
