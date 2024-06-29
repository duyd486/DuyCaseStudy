using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Cinemachine.DocumentationSortingAttribute;

public class DuySceneManager : MonoBehaviour
{
    public Animator anim;

    public void GameLoadScene(string level)
    {
        StartCoroutine(LoadLevel(level));
    }

    IEnumerator LoadLevel(string level)
    {
        anim.SetTrigger("IsEnd");
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(level);
        anim.SetTrigger("IsStart");
    }

}
