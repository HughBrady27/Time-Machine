﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    // MOVEMENT VARS
    public int playerSpeed = 10;
    public bool facingRight = true;
    public float moveInput;

    // JUMPING VARS
    public int playerJumpForce = 200;

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
    }

    void PlayerMove()
    {
        // CONTROLS
        moveInput = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }

        // FACING
        if (moveInput < 0.0f && facingRight == true)
        {
            FlipPlayer();
        }
        else if (moveInput > 0.0f && facingRight == false)
        {
            FlipPlayer();
        }

        // PHYSICS
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveInput * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
    }

    void FlipPlayer()
    {
        facingRight = !facingRight;
        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    void Jump()
    {
        // JUMPING CODE
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * playerJumpForce);
    }
}