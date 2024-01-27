using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D), typeof(SpriteRenderer), typeof(Animator))]

public class SCR_PlayerController : MonoBehaviour
{
    [Header("Movement properties")]
    [Space]
    public float moveSpeed;
    public float jumpMoveSpeed;
    public float jumpForce;

    public GroundCheck groundCheck;
    //public bool isGrounded;
    //public Transform feetPos;
    //public float groundCheckRadius = 0.5f;
    //public LayerMask whatIsGround;

    [Header("Required components info")]
    [Space]
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    private float moveInput;
    private float jumpInput;
    private Boolean isFacingRight = true;

    [Header("Sliders for feel")]
    [Space]
    Vector2 velocity;
    [SerializeField] float airTime;
    const float gravity = -9.8066f;
    Vector2 downwardStickInput;
    [SerializeField] float fallThreshold;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if (groundCheck.isGrounded) rb.velocity = new Vector2(moveInput * moveSpeed * Time.deltaTime, rb.velocity.y);
        else rb.velocity = new Vector2(moveInput * jumpMoveSpeed * Time.deltaTime, rb.velocity.y);

        animator.SetFloat("Velocity", Mathf.Abs(rb.velocity.x));

        if (rb.velocity.x < 0 && isFacingRight)
        {
            FlipSprite();
        }
        else if (rb.velocity.x > 0 && !isFacingRight)
        {
            FlipSprite();
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>().x;
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed && groundCheck.isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, velocity.y);
            //context refers to button press

        }

    }

    public void OnFall(InputAction.CallbackContext context)
    {
        downwardStickInput.y = context.ReadValue<Vector2>().y;

        if (downwardStickInput.y <= fallThreshold && !groundCheck.isGrounded) rb.AddForce(-transform.up * 2f, ForceMode2D.Impulse);

    }


    private void FlipSprite()
    {
        isFacingRight = !isFacingRight;

        Vector3 currentScale = rb.transform.localScale;
        currentScale.x *= -1;

        rb.transform.localScale = currentScale;
    }

    private void OnJumpHold()
    {
        Debug.Log("button hold");
        //connected to jump button when held
    }
    //private bool IsGrounded()
    //{
    //    Vector2 rayDirection = transform.TransformDirection(Vector2.down);
    //    return Physics2D.Raycast(transform.position, rayDirection, groundCheckRadius, whatIsGround);
    //}
}
