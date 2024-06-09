using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject settings;

    private void Start()
    {
        mainMenu.SetActive(true);
        settings.SetActive(false);
    }

    public void PlayGame()
    {
        SoundManager.instance.PlayClickSound();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void OpenSettings()
    {
        SoundManager.instance.PlayClickSound();
        mainMenu.SetActive(false);
        settings.SetActive(true);
    }

    public void CloseSettings()
    {
        SoundManager.instance.PlayClickSound();
        mainMenu.SetActive(true);
        settings.SetActive(false);
    }

    public void ExitGame()
    {
        SoundManager.instance.PlayClickSound();
        Application.Quit();
    }
}
