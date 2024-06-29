using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Animator animator;

    public float horizontal;
    public float runSpeed = 40f;
    public float jumpingPower = 16f;
    private bool isFacingRight = true;


    public float KBForce;
    public float KBCounter;
    public float KBTotalTime;
    public bool KnockFromRight;


    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    public Rigidbody2D playerRb;


    private bool canDash = true;
    private bool isDashing;
    public float dashingPower = 24f;
    public float dashingTime = 0.2f;
    public float dasingCooldown = 1f;

    public GameObject ghostEffect;
    public float ghostDelay;
    private Coroutine dashEffectCoroutine;



    //[SerializeField] private TrailRenderer tr;






    // Update is called once per frame
    void Update()
    {
        if (isDashing)
        {
            return;
        }
        horizontal = ControlFreak2.CF2Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(horizontal));
        Flip();
        
        if (ControlFreak2.CF2Input.GetButtonDown("Jump") && IsGrounded())
        {

            animator.SetTrigger("IsJump");
            playerRb.velocity = new Vector2(playerRb.velocity.x, jumpingPower);
        }
        if(ControlFreak2.CF2Input.GetButtonUp("Jump") && playerRb.velocity.y > 0f)
        {
            playerRb.velocity = new Vector2(playerRb.velocity.x, playerRb.velocity.y * 0.5f);
        }
        if(ControlFreak2.CF2Input.GetKeyDown(KeyCode.K) && canDash)
        {
            StartCoroutine(Dash());
        }
    }



    private void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }
        if (KBCounter <= 0)
        {
            playerRb.velocity = new Vector2(horizontal * runSpeed, playerRb.velocity.y);

        }
        else
        {
            if(KnockFromRight)
            {
                playerRb.velocity = new Vector2(-KBForce, KBForce);
            }
            if(KnockFromRight == false)
            {
                playerRb.velocity = new Vector2(KBForce, KBForce);

            }
            KBCounter -= Time.deltaTime;
        }

    }

    private void Flip()
    {

        if(isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
    

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = playerRb.gravityScale;
        playerRb.gravityScale = 0f;
        playerRb.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        //tr.emitting = true;
        StartDashEffect();
        yield return new WaitForSeconds(dashingTime);
        //tr.emitting = false;
        playerRb.gravityScale = originalGravity;
        isDashing = false;
        StopDashEffect();
        yield return new WaitForSeconds(dasingCooldown);
        canDash = true;
    }



    void StopDashEffect()
    {
        if (dashEffectCoroutine != null) StopCoroutine(dashEffectCoroutine);

    }

    void StartDashEffect()
    {
        if (dashEffectCoroutine != null) StopCoroutine(dashEffectCoroutine);
        dashEffectCoroutine = StartCoroutine(DashEffectCoroutine());
    }


    IEnumerator DashEffectCoroutine()
    {
        while(true)
        {
            GameObject ghost = Instantiate(ghostEffect, transform.position, transform.rotation);
            Sprite currentSprite = GetComponentInChildren<SpriteRenderer>().sprite;
            ghost.GetComponentInChildren<SpriteRenderer>().sprite = currentSprite;
            Destroy(ghost, 0.5f);
            yield return new WaitForSeconds(ghostDelay);
        }
    }

}
