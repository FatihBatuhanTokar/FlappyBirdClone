using UnityEngine;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [System.Serializable]
    public class Sound
    {
        public string name;
        public AudioClip clip;
    }

    public List<AudioClip> sounds = new List<AudioClip>();
    private AudioSource audioSource;

    void Awake()
    {
        // Singleton kontrolü
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        audioSource = gameObject.AddComponent<AudioSource>();
    }

    public void PlaySound(string soundName)
    {
        AudioClip s = sounds.Find(s => s.name == soundName);
        if (s != null)
        {
            audioSource.clip = s;
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("Sound not found: " + soundName);
        }
    }

    public void StopSound()
    {
        audioSource.Stop();
    }
}
