using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeflect : MonoBehaviour, IDeflectable
{

    [SerializeField] private float damage = 1f;
    [SerializeField] private AnimationCurve speedCurve;
    private ItakeDame ItakeDame;


    private Collider2D coll;
    public Collider2D EnemyColl { get;set; }
    [field: SerializeField] public float ReturnSpeed { get; set; } = 10f;
    public bool IsDeflecting { get;set; }

    private Rigidbody2D rb;

    private float speed, time;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        IgnoreCollisionWithEnemyToggle();
    }


    private void FixedUpdate()
    {
        if (IsDeflecting)
        {
            speed = speedCurve.Evaluate(time);
            time += Time.fixedDeltaTime;

            rb.velocity = -transform.right * speed * ReturnSpeed;
        }

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        ItakeDame = collision.gameObject.GetComponent<ItakeDame>();
        if(ItakeDame != null)
        {
            ItakeDame.Damage(damage);
            Destroy(gameObject, 0.2f);
        }
    }

    private void IgnoreCollisionWithEnemyToggle()
    {
        if(!Physics2D.GetIgnoreCollision(coll,EnemyColl)) {
            Physics2D.IgnoreCollision(coll,EnemyColl,true);
        }
        else
        {
            Physics2D.IgnoreCollision(coll, EnemyColl, false);

        }
    }

    public void Deflect(Vector2 direction)
    {
        IsDeflecting = true;
        IgnoreCollisionWithEnemyToggle();
        rb.velocity = direction * ReturnSpeed;

    }
}
