using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, ItakeDame
{
    public float maxHealth = 5f;
    public int addCoin = 1;
    public HealthUI healthUI;
    public Animator animator;
    public GameManager gameManager;

    private float currentHealth = 0;
    private bool isDead;


    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        currentHealth = maxHealth;
        healthUI.SetMaxHeart(maxHealth);
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        //EnemyPatrolAI enemy = collision.GetComponent<EnemyPatrolAI>();
        if (collision.gameObject.tag== "Enemy")
        {
            Damage(1f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin"))
        {
            GameManager.Instance.coinEvent?.Invoke(addCoin);
            Destroy(collision.gameObject);
        }
    }

    public void Damage(float damage)
    {
        animator.SetTrigger("IsHurt");

        currentHealth -= damage;
        healthUI.UpdateHearts(currentHealth);
        Debug.Log("Player hit");

        if (currentHealth <= 0 && !isDead)
        {
            isDead = true;
            Time.timeScale = 0;
            //Die();
            gameManager.gameOver();
        }
    }



    /*void Die()
    {
        //animator.SetBool("IsDead", true);
        Debug.Log("Die");
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }*/
}
