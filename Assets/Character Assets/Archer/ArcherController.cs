using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherController : MonoBehaviour
{
    public float playerMovementSpeed = 5f;
    public float jumpForce = 5f;

    SpriteRenderer spriteRd;
    Animator animatorController;

    Rigidbody2D rbbody;

    bool isGrounded;
    bool isJumping;

    void Start()
    {
        rbbody = GetComponent<Rigidbody2D>();
        spriteRd = GetComponent<SpriteRenderer>();
        animatorController = GetComponent<Animator>();
    }

    void Update()
    {
        float movementX = Input.GetAxis("Horizontal");

        rbbody.velocity = new Vector2(movementX * playerMovementSpeed, rbbody.velocity.y);

        if (Math.Abs(rbbody.velocity.x) > 1f)
        {
            animatorController.SetInteger("switchAni", 1);
        }
        else
        {
            animatorController.SetInteger("switchAni", 0);
        }

        if (rbbody.velocity.x < 0)
        {
            spriteRd.flipX = true;
        }
        else if (rbbody.velocity.x > 0)
        {
            spriteRd.flipX = false;
        }

        // Check for ground collision
        if (Physics2D.Raycast(transform.position, Vector2.down, 0.5f))
        {
            isGrounded = true;
            isJumping = false; // Reset jumping flag
        }
        else
        {
            isGrounded = false;
        }

        // Handle jumping
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && !isJumping)
        {
            rbbody.velocity = new Vector2(rbbody.velocity.x, jumpForce);
            animatorController.SetTrigger("Jump");
            isJumping = true; // Set jumping flag
        }
    }
}