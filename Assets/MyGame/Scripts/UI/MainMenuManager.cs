using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{

    public GameObject panelOption;
    public Slider sliderMusic;
    public Slider sliderSfx;

    void Start()
    {
        GetDataVolume();
        panelOption.SetActive(false);
    }

    void GetDataVolume()
    {
        sliderMusic.value = DataManager.DataMusic;
        sliderSfx.value = DataManager.DataSfx;
        AudioManager.Instance.SetMusicVolume(sliderMusic.value);
        AudioManager.Instance.SetSfxVolume(sliderSfx.value);
    }


    public void OnOptionClick()
    {
        panelOption.SetActive(true);
    }
    public void OnXClick()
    {
        panelOption.SetActive(false );
    }

    public void SetMusicVolume(float volume)
    {
        AudioManager.Instance.SetMusicVolume(volume);
    }
    public void SetSfxVolume(float volume)
    {
        AudioManager.Instance.SetSfxVolume(volume);
    }





    public void OnExitClick()
    {
        Application.Quit();
    }
}
