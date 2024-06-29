using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public PlayerHealth health;
    public Transform attackPoint;
    public Animator animator;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    //public LayerMask bossLayer;
    public float attackDamage = 1f;
    public float attackRate = 2f;
    float nextAttack = 0f;


    public int combo;
    public bool attack;


    public GameObject blood;



    private void Start()
    {
        animator = GetComponent<Animator>();
        health = GetComponentInParent<PlayerHealth>();
    }


    private void Update()
    {
        if (Time.time >= nextAttack)
        {
            if (ControlFreak2.CF2Input.GetKeyDown(KeyCode.J) )
            {
                if(combo >= 3)
                {
                    combo = 0;
                }
                //Attack();
                attack = true;
                animator.SetTrigger("" + combo);
                nextAttack = Time.time + 1f / attackRate;
            }
       }

    }
    void Attack()
    {
        if (!health.isDead)
        {
            //animator.SetTrigger("IsAttack");

            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

            foreach (Collider2D enemy in hitEnemies)
            {
                if (enemy.gameObject.layer == 7)
                {
                    enemy.GetComponent<EnemiesHealth>().Damage(attackDamage);
                }
                if (enemy.gameObject.layer == 10)
                {
                    enemy.GetComponent<BossHealth>().Damage(attackDamage);
                }

                IDeflectable iDeflectable = enemy.gameObject.GetComponent<IDeflectable>();
                if (iDeflectable != null)
                {
                    iDeflectable.Deflect(transform.right);
                    //Debug.Log("deflect2");
                }

                Instantiate(blood, enemy.transform.position, Quaternion.identity);

            }

        }
    }

    public void StartCombo()
    {
        attack = false;
        if(combo < 3)
        {
            combo++;
        }
    }

    public void FinishAnim()
    {
        attack = false;
        combo = 0;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
