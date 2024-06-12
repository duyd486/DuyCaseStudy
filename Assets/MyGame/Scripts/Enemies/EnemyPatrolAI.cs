using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolAI : MonoBehaviour
{

    [SerializeField] float moveSpeed = 1f;
    public float damage = 1f;

    BoxCollider2D myBox;
    Rigidbody2D myRigid;

    void Start()
    {
        myRigid = GetComponent<Rigidbody2D>();
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

}
