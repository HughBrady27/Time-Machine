using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    // MOVEMENT VARS
    public int playerSpeed = 10;
    public bool facingRight = true;
    public float moveInput;

    // JUMPING VARS
    public int playerJumpForce = 300;
    public bool isGrounded = false;
    public bool doubleJump = true;

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
        PlayerRaycast();
    }

    void PlayerMove()
    {
        // CONTROLS
        moveInput = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            Jump();
        } 
        else if (Input.GetButtonDown("Jump") && isGrounded != true && doubleJump == true)
        {
            doubleJump = false;
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
        isGrounded = false;
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * playerJumpForce);
    }

    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.tag == "Ground") {
            Debug.Log("landed on ground");
            doubleJump = true;
            isGrounded = true;
        }
    }

    void PlayerRaycast() {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down);
        if (hit.distance < 1.1f && hit.collider.tag == "Enemy") {
        //    Debug.Log("touching enemy");
            GetComponent<Rigidbody2D>().AddForce (Vector2.up * 1000);
        }
       
    }
}
