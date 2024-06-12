using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DuySceneManager : MonoBehaviour
{
    public void GameLoadScene(string level)
    {
        SceneManager.LoadScene(level);
    }
}
