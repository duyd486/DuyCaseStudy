using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get => instance; }

    public static AudioManager instance;

    public AudioSource musicSource;
    public AudioSource sfxSource;
    public AudioClip backgroundMusic;

    private void Awake()
    {
        if (instance != null)
        {
            DestroyImmediate(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        PlayBackgroundMusic(backgroundMusic);
    }

    void PlayBackgroundMusic(AudioClip clip)
    {
        musicSource.clip = clip;
        musicSource.loop = true;
        musicSource.Play();
    }

    public void PlaySfx(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }
    public void SetMusicVolume(float volume)
    {
        DataManager.DataMusic = volume;
        musicSource.volume = volume;
    }
    public void SetSfxVolume(float volume)
    {
        DataManager.DataSfx = volume;
        musicSource.volume = volume;
    }

}
