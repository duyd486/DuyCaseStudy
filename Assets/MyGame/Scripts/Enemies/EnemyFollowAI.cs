using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowAI : MonoBehaviour
{
    [SerializeField] Vector2 idelMoveDirection;


    public float speed = 5f;
    public float lineOfSite;
    public float shootingRange;
    public GameObject bullet;
    public GameObject bulletParent;
    public float fireRate = 1f;


    private float nextFireTime;
    private Transform player;
    private bool facingLeft = false;
    private Transform enemy;
    private EnemyDeflect EnemyDeflect;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        
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
            Instantiate(bullet, bulletParent.transform.position, Quaternion.identity);
            nextFireTime = Time.time + fireRate;
        }




        FlipTowardPlayer();

    }

    private void Shoot()
    {
        
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
