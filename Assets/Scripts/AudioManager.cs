using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip audioClip;
    [Range(0f, 1f)]
    public float volume = 1f;
    [Range(0f, 1f)]
    public float pitch = 0.5f;

    private AudioSource audioSource;

    public void setSound(AudioSource _audioSource)
    {
        this.audioSource = _audioSource;
        audioSource.clip = audioClip;
    }

    public void Play()
    {
        audioSource.volume = volume;
        audioSource.pitch = pitch;
        audioSource.Play();
    }
}

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance; //= null;

    [SerializeField]
    private Sound[] sounds;

    private void Awake()
    {
        if (instance ==  null)
        {
            instance = this;
        }
        else if (instance != this)
        {
           Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    private void Start()
    {
        foreach (var sound in sounds)
        {
            sound.setSound(new GameObject().AddComponent<AudioSource>());
        }
    }

    // Update is called once per frame
    public void Play(string _name)
    {
        foreach (var sound in sounds)
        {
            if (sound.name == _name)
            {
                sound.Play();
            }
        }
    }
}
