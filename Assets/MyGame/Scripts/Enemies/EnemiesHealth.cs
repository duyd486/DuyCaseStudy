using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesHealth : MonoBehaviour, ItakeDame
{
    public Animator animator;
    public float dieTime = 1f;
    [SerializeField] private float maxHealth = 3f;
    //public float dame;

    private float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }



    public void Damage(float damage)
    {
        animator.SetTrigger("IsHurt");

        currentHealth -= damage;
        //Debug.Log("Enemy hit");

        if (currentHealth <= 0)
        {
            Die();
            Destroy(gameObject, dieTime);
        }
    }




    void Die()
    {
        //Debug.Log("Die");
        animator.SetBool("IsDead", true);

    }

}
