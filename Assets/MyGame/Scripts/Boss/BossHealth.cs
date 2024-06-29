using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BossHealth : MonoBehaviour, ItakeDame
{
    public Image healthBar;

    //public HealthManager healthManager;

    public float health = 21f;

    public bool isInvulnerable = false;

    public GameObject bossBar;



    public void Damage(float damage)
    {

        if (isInvulnerable)
            return;

        health -= damage;
        healthBar.fillAmount = health / 21f;

        if (health <= 14f)
        {
            GetComponent<Animator>().SetBool("IsEnraged", true);
        }
        if (health <= 7f)
        {
            GetComponent<Animator>().SetBool("IsEnraged2", true);
        }

        if (health <= 0)
        {
            Die();
        }

        Debug.Log("Boss hit");

    }

    void Die()
    {
        //Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
        bossBar.SetActive(false);
    }

}
