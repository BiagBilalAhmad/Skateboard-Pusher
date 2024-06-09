using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public GameObject losePanel;

    [Header("Ground Colliders")]
    public GameObject topGroundColldier;
    public GameObject bottomGroundColldier;

    private void Start()
    {
        Time.timeScale = 1f;
        losePanel.SetActive(false);
    }

    public void GetTopGroundCollider()
    {
        topGroundColldier.SetActive(true);
        bottomGroundColldier.SetActive(false);
    }

    public void GetBottomGroundCollider()
    {
        topGroundColldier.SetActive(false);
        bottomGroundColldier.SetActive(true);
    }

    public void ShowLosePanel()
    {
        Time.timeScale = 0f;
        losePanel.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
