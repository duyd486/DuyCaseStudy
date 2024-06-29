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
    public GameObject enemies;
    public GameObject BossBlock;
    public GameObject bossBar;
    public GameObject loveGhost;

    private float currentHealth = 0;
    public bool isDead;





    // Start is called before the first frame update
    void Start()
    {
        isDead = false;
        loveGhost.SetActive(true);
        bossBar.SetActive(false);
        BossBlock.SetActive(false);
        Time.timeScale = 1;
        currentHealth = maxHealth;
        healthUI.SetMaxHeart(maxHealth);
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
            
            animator.SetBool("IsDead", true);
            isDead = true;
            StartCoroutine(GameOver());
        }
    }

    private IEnumerator GameOver()
    {
        yield return new WaitForSeconds(1.2f);
        Time.timeScale = 0f;
        gameManager.gameOver();
    }




    /*void Die()
    {
        //
        Debug.Log("Die");
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }*/
}
