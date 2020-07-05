﻿
using System;
using UnityEngine;

public class PlayerMovement : AbstractMode
{

    //all of this should get from weapon
    //public GameObject weapon;
    public ParticleSystem jumpParticles;
    public ParticleSystem wallJumpParticles;

    public Movement movement;

    public float jumpCd;
    private float lastJumpTime;
    public float speed;
    public float jumpSpeed;
    private float moveInput;
    private float facingRight = 1;
    private Rigidbody2D rb;

    private bool isGrounded = false;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    public int extraJumps;
    private int currentJumps = 0;

    public Transform wallCheck;
    private bool onWall = false;
    public float walljumpYspeed;
    public float walljumpSideSpeed;
    public float playerGravity;
    public float playerWallGravity;

    public float airControl;
    public float groundControl;
    private float control;

    public Animator animator;
    public LayerMask groundLayer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        

    }

    void FixedUpdate()
    {
        if (modeManager.CanMove())
        {
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
            onWall = !isGrounded && Physics2D.OverlapCircle(wallCheck.position, groundCheckRadius, whatIsGround);
            animator.SetBool("onWall", onWall);
            control = isGrounded ? groundControl : airControl;
            if (onWall)
            {
                rb.gravityScale = rb.velocity.y < -1 ? playerWallGravity : playerGravity;
                //print("wow on a wall" + Time.time);
            }
            else
            {
                rb.gravityScale = playerGravity;
            }
            if (!isGrounded && !onWall)
            {
                animator.SetBool("jumping", true);
            }
            else
            {
                animator.SetBool("jumping", false);
            }
            moveInput = Input.GetAxis("Horizontal");
            animator.SetBool("running", moveInput != 0);
            Vector2 wantedVelocity = new Vector2(moveInput * speed, rb.velocity.y);
            rb.velocity = Vector2.Lerp(rb.velocity, wantedVelocity, control);
            //rb.velocity = new Vector2(moveInput * speed, rb.velocity.y); //todo: fix lerp for walljump
            if (facingRight == 1 && rb.velocity.x < 0)
            {
                Flip();
            }
            else if (facingRight == -1 && rb.velocity.x > 0)
            {
                Flip();
            }
        }
    }
    private void Update()
    {
        if (modeManager.CanMove())
        {
            if (lastJumpTime + jumpCd < Time.time)
            {
                if (isGrounded)
                {
                    currentJumps = extraJumps;
                }
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    if (isGrounded)
                    {
                        currentJumps = extraJumps;
                    }
                    bool jumped = false;
                    if (onWall)
                    {
                        rb.velocity = new Vector2(walljumpSideSpeed * facingRight * -1, walljumpYspeed);
                        wallJumpParticles.Play();
                        jumped = true;
                    }
                    else if (isGrounded)
                    {
                        rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
                        jumpParticles.Play();
                        jumped = true;
                    }
                    else if (currentJumps > 0)
                    {

                        rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
                        currentJumps--;
                        jumpParticles.Play();
                        jumped = true;
                    }

                    if (jumped)
                    {
                        SoundManager.PlaySound(SoundManager.Sound.PlayerJump, transform.position);
                        lastJumpTime = Time.time;
                    }
                }
            }
        }
    }
    void Flip()
    {
        facingRight = facingRight * -1;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }
}
