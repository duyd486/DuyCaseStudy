using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject PausePanel;
    public DuySceneManager SceneManager;
    public void OnPauseClick()
    {
        Time.timeScale = 0f;
        PausePanel.SetActive(true);
    }
    public void OnResumeClick()
    {
        Time.timeScale = 1f;
        PausePanel.SetActive(false);
    }
    public void OnRestartClick()
    {
        PausePanel.SetActive(false);

        SceneManager.GameLoadScene("Level1");
        Time.timeScale = 1f;

    }
    public void OnMainMenuClick()
    {
        PausePanel.SetActive(false);

        SceneManager.GameLoadScene("MainMenu");
        Time.timeScale = 1f;

    }
}
