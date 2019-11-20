using UnityEngine;

public class MusicLoop : MonoBehaviour
{
    private         AudioSource     audioSource;
    private static  MusicLoop       instance = null;
    public static   MusicLoop       Instance { get { return instance; } }

    private void Awake()
    {
        if (instance != null && Instance != null)
            Destroy(this.gameObject);
        else
            instance = this;          
        DontDestroyOnLoad(this.gameObject);
        audioSource = GetComponent<AudioSource>();       
    }

    public void Stop()
    {
        audioSource.Stop();
    }

    public void Play()
    {
        audioSource.Play();
    }
}
