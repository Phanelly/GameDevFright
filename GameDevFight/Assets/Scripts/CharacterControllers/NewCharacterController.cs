using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewCharacterController : MonoBehaviour
{
    public int collectiblesCount = 0;

    [Header("Movement")]
    [SerializeField] private float movementSpeed = 200f;
    [SerializeField] private float jumpForce = 10f;

    [Header("Ground")]
    [SerializeField] private Vector2 groundCheckSize;
    [SerializeField] private LayerMask groundMask;
    private Transform groundCheck;

    [Header("Art")]
    [SerializeField] private SpriteRenderer sp;
    [SerializeField] private bool facingRight = true;

    private float horizontal;
    private bool jump = false;

    private Transform t;
    private Rigidbody2D rb;


    void Start()
    {
        t = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();

        groundCheck = GetComponentsInChildren<Transform>()[1];
    }


    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            jump = true;
        }

        if ((horizontal > 0 && !facingRight) || (horizontal < 0 && facingRight))
            Flip();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * movementSpeed * Time.fixedDeltaTime, rb.velocity.y);

        if (jump)
        {
            rb.velocity += new Vector2(0, jumpForce);
            //rb.AddForce(new Vector2(0, jumpForce * 10));
            jump = false;
        }
    }

    bool IsGrounded()
    {
        Collider2D collider = Physics2D.OverlapBox(groundCheck.position, groundCheckSize, 0f, groundMask);

        return collider != null;
    }

    private void Flip()
    {
        facingRight = !facingRight;
        t.Rotate(0f, 180f, 0f);
    }


    /*private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 1, 0, 0.75F);
        Gizmos.DrawWireCube(groundCheck.position, groundCheckSize);
    }*/
}
