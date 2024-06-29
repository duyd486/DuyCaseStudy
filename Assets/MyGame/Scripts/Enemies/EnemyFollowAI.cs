using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyFollowAI : MonoBehaviour
{
    [SerializeField] Vector2 idelMoveDirection;


    public float speed = 5f;
    public float bulletSpeed = 7f;
    public float lineOfSite;
    public float shootingRange;
    public Rigidbody2D bullet;
    public GameObject bulletParent;
    public float fireRate = 1f;
    public float jumpForce = 300f;


    private float nextFireTime;
    private Transform player;
    private bool facingLeft = false;
    private Transform enemy;
    private EnemyDeflect enemyDeflect;
    private Rigidbody2D rb;
    private Rigidbody2D bulletRB;
    private Collider2D coll;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);
        if(distanceFromPlayer < lineOfSite && distanceFromPlayer > shootingRange)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);

        } else if (distanceFromPlayer <  shootingRange && nextFireTime < Time.time)
        {
            Shoot();
        }




        FlipTowardPlayer();

    }

    private void Shoot()
    {
        bulletRB = Instantiate(bullet, transform.position, transform.rotation);

        bulletRB.velocity = bulletRB.transform.right * bulletSpeed;

        enemyDeflect = bulletRB.gameObject.GetComponent<EnemyDeflect>();

        enemyDeflect.EnemyColl = coll;

        nextFireTime = Time.time + fireRate;
    }

    private void OnCollisionEnter2D(UnityEngine.Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            rb.AddForce(new Vector2(0f, jumpForce));
            Debug.Log("player near");

        }

    }



    void FlipTowardPlayer()
    {
        float playerDirection = player.position.x - transform.position.x;
        if(playerDirection > 0 && facingLeft)
        {
            Flip();
        }
        else if(playerDirection < 0 && !facingLeft)
        {
            Flip();
        }
    }

    void Flip()
    {
        facingLeft = !facingLeft;
        idelMoveDirection.x *= -1;
        transform.Rotate(0, 180, 0);

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, lineOfSite);
        Gizmos.DrawWireSphere(transform.position, shootingRange);

    }

}
