using UnityEngine;

public class musicmanager : MonoBehaviour
{
    private static musicmanager instance;
    private AudioSource audioSource;
    public AudioClip bgm;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            audioSource = GetComponent<AudioSource>();
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called once before the first execution of Update
    void Start()
    {
        if (bgm != null)
        {
            playbg(false, bgm);
        }
    }

    public static void playbg(bool resetSong, AudioClip audioClip = null)
    {
        if (instance == null || instance.audioSource == null)
        {
            return;
        }

        if (audioClip != null)
        {
            instance.audioSource.clip = audioClip;
        }

        if (instance.audioSource.clip != null)
        {
            if (resetSong)
            {
                instance.audioSource.Stop();
            }
            if (!instance.audioSource.isPlaying)
            {
                instance.audioSource.Play();
            }
        }
    }

    public static void pausebg()
    {
        if (instance == null || instance.audioSource == null)
        {
            return;
        }

        instance.audioSource.Pause();
    }
}
