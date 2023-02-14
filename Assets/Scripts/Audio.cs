using UnityEngine.SceneManagement;
using UnityEngine;


public class Audio : MonoBehaviour
{
    public static Audio Instance;

    private AudioSource audioSource;
    public AudioClip[] gameMusic;
    public AudioClip[] soundEffects;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        audioSource = GetComponent<AudioSource>();
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        PlayMusic();
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public void PlayMusic()
    {
        int musicClip = SceneManager.GetActiveScene().buildIndex;
        audioSource.clip = gameMusic[musicClip];
        audioSource.Play();
    }

    private void PlaySoundEffect()
    {
        audioSource.clip = soundEffects[1];
        audioSource.Play();
    }

    public void PlaySoundEffectWithDelay(int index)
    {
        audioSource.clip = soundEffects[index];
        audioSource.Play();
        if (index == 0)
        {
            Invoke("PlaySoundEffect", 1f);
        }
    }
}