using System;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float jumpForce;
    [SerializeField]
    private float sprintSpeed;
    [SerializeField]
    private LayerMask groundLayer;
    [SerializeField]
    private LayerMask wallLayer;
    private Rigidbody2D body;
    private Animator anim;
    private CapsuleCollider2D capsuleCollider;
    private float wallJumpCooldown;
    private float horizontalInput;

    private void Awake()
    {
        //Get references for rigidbody and animator from object
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();
    }

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");


        //Flip player when moving left or right
        if (horizontalInput > 0.01f)
        {
            transform.localScale = Vector3.one;
        }
        else if (horizontalInput < -0.01f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        //Set animator parameters
        anim.SetBool("Walk", horizontalInput != 0);
        anim.SetBool("Sprint", Input.GetKey(KeyCode.LeftShift) == true && isGrounded() == true);
        anim.SetBool("Grounded", isGrounded());

        //Wall Jump logic
        if (wallJumpCooldown > 0.2f)
        {
            

            body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

                if (onWall() && !isGrounded())
                {
                    body.gravityScale = 0;
                    body.velocity = Vector2.zero;
                }
                else
                {
                    body.gravityScale = 3;
                }
                if (Input.GetKey(KeyCode.Space))
                {
                    Jump();
                }

        }
        else
        {
            wallJumpCooldown += Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.LeftShift) /*&& grounded*/)
        {
            Sprint();

        }
    }

    private void Jump()
    {
        if (isGrounded())
        {
            body.velocity = new Vector2(body.velocity.x, jumpForce);
            anim.SetTrigger("Jump");
            //isGrounded();
        }
        else if (onWall() && !isGrounded())
        {
            if (horizontalInput == 0)
            {
                body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 9, 0);
                //Flip the character on wall jump
                transform.localScale = new Vector3(-MathF.Sign(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
            else
            {
                body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 4, 8);
            }
            wallJumpCooldown = 0;
            
        }
    }

    private void Sprint()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput * sprintSpeed, body.velocity.y);
        anim.SetTrigger("Sprint");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.gameObject.tag == "Ground" )
        //{
        //    grounded = true;
        //}
    }

    private bool isGrounded()
    {
        RaycastHit2D raycastHit =
            Physics2D.BoxCast(capsuleCollider.bounds.center, capsuleCollider.bounds.size, 0, new Vector2(transform.localScale.x, 0), 0.1f, groundLayer);
        //returns true or false whether player is grounded or not.
        return raycastHit.collider != null;
    }

    //Implementing wall jump
    private bool onWall()
    {
        RaycastHit2D raycastHit =
            Physics2D.BoxCast(capsuleCollider.bounds.center, capsuleCollider.bounds.size, 0, Vector2.down, 0.1f, wallLayer);
        //returns true or false whether player is grounded or not.
        return raycastHit.collider != null;
    }
}
