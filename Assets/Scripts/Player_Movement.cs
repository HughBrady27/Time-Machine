using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player_Movement : MonoBehaviour
{
    // MOVEMENT VARS
    public int playerSpeed = 10;
    public bool facingRight = true;
    public float moveInput;

    // JUMPING VARS
    public int playerJumpForce = 800;
    public bool isGrounded = false;
    public bool doubleJump = true;
    public float distToFoot = 1.6f;
    [SerializeField]
    private Rigidbody2D rb;

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

        if (Input.GetButtonDown("Jump") && isGrounded == true) {
            Jump();
        } 
        else if (Input.GetButtonDown("Jump") && isGrounded != true && doubleJump == true) {
            doubleJump = false;
            Jump();
        }

        // FACING
        if (moveInput < 0.0f && facingRight == true) {
            FlipPlayer();
        }
        else if (moveInput > 0.0f && facingRight == false) {
            FlipPlayer();
        }

        // Move
        rb.velocity = new Vector2(moveInput * playerSpeed, rb.velocity.y);
    }

    void MoveLeft() {
        
    }

    void MoveRight() {

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
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * playerJumpForce);
    }

    // Casting a ray down from the player, checking for enemies or the ground.
    void PlayerRaycast() {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down);
        
        if (hit.collider != null && hit.distance < distToFoot && hit.collider.tag == "Ground") {
            isGrounded = true;
            doubleJump = true;
        }
        else {
            isGrounded = false;
        }
        
        if (hit.collider != null && hit.distance < distToFoot && hit.collider.tag == "Enemy") {
            doubleJump = true;
            GetComponent<Rigidbody2D>().AddForce (Vector2.up * 1000);
            hit.collider.gameObject.GetComponent<Rigidbody2D>().gravityScale = 6;
            hit.collider.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            hit.collider.gameObject.GetComponent<Goon_Behaviour>().enabled = false;
        }
       
    }
}
