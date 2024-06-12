using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Transform attackPoint;
    public Animator animator;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public float attackDamage = 1f;
    public float attackRate = 2f;
    float nextAttack = 0f;
    private void Update()
    {
        if (Time.time >= nextAttack)
        {
            if (Input.GetKeyDown(KeyCode.J))
            {
                Attack();
                nextAttack = Time.time + 1f / attackRate;
            }
        }

    }
    void Attack()
    {
        animator.SetTrigger("IsAttack");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<EnemiesHealth>().Damage(attackDamage);
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
