using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandingScripts : MonoBehaviour
{
    public Animator animator;
    public void OnLanding()
    {
        animator.SetBool("IsJump", false);
    }
    private void Update()
    {

        if (Input.GetButtonDown("Jump"))
        {
            animator.SetBool("IsJump", true);
        }
    }

}
