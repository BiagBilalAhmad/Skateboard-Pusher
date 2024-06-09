using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public AudioSource audioSource;
    public AudioSource musicSource;

    public Toggle volumeToggle;
    public Toggle musicToggle;

    [Header("Clips")]
    public AudioClip click;

    private void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        if (PlayerPrefs.GetInt("Allow Music", 1) == 0)
            musicToggle.isOn = false;
        else
            musicToggle.isOn = true;

        ToggleMusic();

        if (PlayerPrefs.GetInt("Allow Volume", 1) == 0)
            volumeToggle.isOn = false;
        else
            volumeToggle.isOn = true;

        ToggleVolume();
    }

    public void PlayClickSound()
    {
        audioSource.PlayOneShot(click);
    }

    public void ToggleVolume()
    {
        int toggle = volumeToggle.isOn ? 1 : 0;
        audioSource.volume = toggle;
        PlayerPrefs.SetInt("Allow Volume", toggle);
    }

    public void ToggleMusic()
    {
        int toggle = musicToggle.isOn ? 1 : 0;
        musicSource.volume = toggle;
        PlayerPrefs.SetInt("Allow Music", toggle);
    }
}
