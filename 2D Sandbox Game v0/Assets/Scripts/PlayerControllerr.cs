using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerr : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public float moveInput;
    
    private bool KopfRight = true;
    private bool isGrounded = true;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;

    private Rigidbody2D rb;
    private Animator anim;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        moveInput = Input.GetAxis("Horizontal");
        Move();    
    }

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);
        if(isGrounded && Input.GetKeyDown(KeyCode.Space)) Jump();

        if(isGrounded)
            anim.SetBool("isJumping",false);
        else 
            anim.SetBool("isJumping",true);
    }

    private void Move()
    {
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        
        if(moveInput<0 && KopfRight) Flip();
        else if(moveInput>0 && KopfRight == false) Flip();
        
        if(moveInput == 0) anim.SetBool("isRunning", false);
        else anim.SetBool("isRunning", true); 
    }

    private void Jump()
    {
        rb.velocity = Vector2.up * jumpForce;
        anim.SetTrigger("takeOff");
    }

    private void Flip()
    { 
        if(moveInput < 0 )
            transform.eulerAngles = new Vector3(0,180,0);
        else if (moveInput >0)
            transform.eulerAngles = new Vector3(0,0,0); 


            KopfRight=!KopfRight;
            Vector3 Scaler = transform.localScale;
            Scaler.x *= -1;
            transform.localScale = Scaler;
    }
}
