using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] [Range(100, 500)] private float movementSpeed = 200f;
    [SerializeField] [Range(1, 20)] private float jumpForce = 2f;
    [SerializeField] [Range(0, 1)] private float movementSmoothing = 0f;

    [Header("GroundedSettings")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] [Range(0.001f, 1f)]private float groundCheckRadius = 0.1f;
    [SerializeField] private LayerMask groundLayer;

    [Header("Art")]
    [SerializeField] private SpriteRenderer sp;
    [SerializeField] private bool facingRight = true;

    private float horizontal = 0f;
    private bool jump = false;

    private Transform t;
    private Rigidbody2D rb;

    private Vector3 zeroVelocity = Vector3.zero;

    private void Start()
    {
        t = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && IsGrounded())
            jump = true;

        if ((horizontal > 0 && !facingRight) || (horizontal < 0 && facingRight))
            Flip();
    }

    private void FixedUpdate()
    {
        Vector2 velocity = new Vector2(horizontal * movementSpeed * Time.fixedDeltaTime, rb.velocity.y);

        if (jump)
        {
            velocity += new Vector2(0, jumpForce);
            //rb.AddForce(new Vector2(0, jumpForce * 100));
            jump = false;
        }


        rb.velocity = Vector3.SmoothDamp(rb.velocity, velocity, ref zeroVelocity, movementSmoothing);
    }

    private bool IsGrounded()
    {
        Collider2D colliders = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        return colliders != null;
    }

    private void Flip()
    {
        facingRight = !facingRight;
        t.Rotate(0f, 180f, 0f);
    }
}
