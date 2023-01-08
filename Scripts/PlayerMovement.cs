using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    public float speed = 8f;
    public float jumpingPower = 16f;
    private bool isFacingRight = true;

    public Transform wallCheck;
    bool isWallTouch;
    bool isSliding;
    public float wallSlideSpeed;

    private Rigidbody2D rb;
    private Animator animator;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
     

    private void Start()
    {
        TimeScaleManager.ResumeTime();
        rb = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        animator.SetFloat("Speed", Mathf.Abs(horizontal));

        if (Input.GetKey(KeyCode.W) && IsGrounded())
        {
            animator.SetBool("Jumping", true);
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        } 

        if (rb.velocity == new Vector2(rb.velocity.x, 0))
        {
            animator.SetBool("Jumping", false);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            animator.SetBool("Crouching", true);
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            animator.SetBool("Crouching", false);
        }

        isWallTouch = Physics2D.OverlapBox(wallCheck.position, new Vector2(0.05f, 0.2f), 0, groundLayer);

        if(isWallTouch && !IsGrounded() && horizontal != 0)
        {
            isSliding = true;
        }
        else
        {
            isSliding = false;
        }

        Flip();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

        if (isSliding)
        {
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -wallSlideSpeed, float.MaxValue));
        }

    }

    public bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        if(isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

}
