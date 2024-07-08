using UnityEngine;

public class Sound : MonoBehaviour
{
    private static Sound instance;

    public AudioClip musicClip;
    private AudioSource musicSource;

    public float Volume { get; private set; } = 1f; // Volume property

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        musicSource = gameObject.AddComponent<AudioSource>();
        musicSource.clip = musicClip;
        musicSource.loop = true;
        musicSource.volume = Volume;
        musicSource.Play();
    }

    public void ChangeMusic(AudioClip newClip)
    {
        musicSource.Stop();
        musicSource.clip = newClip;
        musicSource.Play();
    }

    public void SetVolume(float volume)
    {
        Volume = Mathf.Clamp01(volume); // Ensure volume is between 0 and 1
        musicSource.volume = Volume;
    }
}
