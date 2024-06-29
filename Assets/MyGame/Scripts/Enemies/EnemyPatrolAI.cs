using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolAI : MonoBehaviour
{

    [SerializeField] float moveSpeed = 1f;
    public float damage = 1f;
    public PlayerController playerController;
    private PlayerHealth player;



    BoxCollider2D myBox;
    Rigidbody2D myRigid;

    void Start()
    {
        myRigid = GetComponent<Rigidbody2D>();
        playerController = GameObject.FindObjectOfType<PlayerController>();
        player = GameObject.FindObjectOfType<PlayerHealth>();

    }

    void Update()
    {
        if (IsFacingRight())
        {
            myRigid.velocity = new Vector2(moveSpeed,0f);
        }
        else
        {
            myRigid.velocity = new Vector2(-moveSpeed, 0f);
        }
    }

    private bool IsFacingRight()
    {
        return transform.localScale.x > Mathf.Epsilon;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.localScale = new Vector2(-(Mathf.Sign(myRigid.velocity.x)), transform.localScale.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //EnemyPatrolAI enemy = collision.GetComponent<EnemyPatrolAI>();
        if (collision.gameObject.tag == "Player")
        {
            playerController.KBCounter = playerController.KBTotalTime;
            if (collision.transform.position.x <= transform.position.x)
            {
                playerController.KnockFromRight = true;
            }
            if (collision.transform.position.x > transform.position.x)
            {
                playerController.KnockFromRight = false;
            }

            player.Damage(damage);
        }
    }



}
