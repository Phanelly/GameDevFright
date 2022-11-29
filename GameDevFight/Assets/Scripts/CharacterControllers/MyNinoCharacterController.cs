using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyNinoCharacterController : MonoBehaviour
{
    private Transform t;
    private Rigidbody2D rb;
    private Animator a;
    private Collider2D c;

    private bool jump = false;
    private bool facingRight = false;
    private bool isGrounded = false;
    private bool doubleJumpAvaiable = false;
    private bool charging = false;
    private bool chargedJump = false;
    private bool dash = false;
    private bool dashAvaiable = false;
    private float horizontal;
    private float vertical;
    private float lastTimeGrounded;
    private float chargeTimer = 0f;
    private Vector3 zeroVelocity = Vector3.zero;


    [Header("Movement")]
    [SerializeField] [Range(10f, 100f)] private float movementSpeed = 10f;
    [SerializeField] [Range(0f, 1f)] private float movementSmoothing = 0.5f;
    [SerializeField] [Range(10f, 100f)] private float jumpForce = 100f;
    [SerializeField] [Range(0f, 5f)] private float fallMultiplier = 2.5f;
    [SerializeField] [Range(0f, 5f)] private float lowJumpMultiplier = 2f;
    [SerializeField] [Range(0f, .5f)] private float groundedMemory = 0f;
    [SerializeField] [Range(0f, 5f)] private float chargingTime = 1f;
    [SerializeField] [Range(1f, 5f)] private float chargedJumpMultiplier = 2.5f;
    [SerializeField] [Range(10f, 100f)] private float dashForce = 20f;

    [Header("GroundedSettings")]
    [SerializeField] private Transform isGroundedChecker;
    [SerializeField] private float checkGroundRadius;
    [SerializeField] private LayerMask groundLayer;

    [Header("CombatSettings")]
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float attackRange;
    [SerializeField] private LayerMask enemiesLayer;

    [Header("Masks")]
    [SerializeField] private LayerMask npcLayer;
    [SerializeField] private LayerMask obstaclLayer;

    [Header("Abilities")]
    [SerializeField] private bool canMove = true;
    [SerializeField] private bool canDoubleJump = false;
    [SerializeField] private bool canChargeJump = false;
    [SerializeField] private bool canDashJump = false;

    [SerializeField] private GameObject particles;

    private void Start()
    {
        t = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        c = GetComponent<Collider2D>();
        a = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        Jump();

        //Attack();

        particles.SetActive(charging);
    }

    private void FixedUpdate()
    {
        if (canMove)
        {
            switch (vertical)
            {
                case 1:
                    // Looking up
                    break;
                case -1:
                    // Looking down                   
                    break;
            }



            var velocity = new Vector3(horizontal * movementSpeed, rb.velocity.y, 0) * Time.fixedDeltaTime * 10;

            if ((velocity.x > 0 && !facingRight) || (velocity.x < 0 && facingRight))
                Flip();

            if (jump)
            {
                rb.velocity += new Vector2(0, jumpForce);
                jump = false;
                a.SetTrigger("Jump");
            }
            if (chargedJump)
            {
                rb.velocity += new Vector2(0, jumpForce * chargedJumpMultiplier);
                chargedJump = false;
            }
            if (dash)
            {
                var direction = (facingRight) ? +1 : -1;

                //rb.AddForce(new Vector2(dashForce * direction *100, 0));
                rb.velocity += new Vector2(dashForce * direction, 0);
                dash = false;
            }

            a.SetFloat("Speed", Mathf.Abs(velocity.x));
            a.SetFloat("VerticalSpeed", velocity.y);

            rb.velocity = Vector3.SmoothDamp(rb.velocity, velocity, ref zeroVelocity, movementSmoothing);
        }
        else
        {
            rb.velocity = new Vector3(0, -1, 0);
        }

        if (charging && Input.GetKey(KeyCode.S))
            chargeTimer -= Time.fixedDeltaTime;
    }

    private void Flip()
    {
        facingRight = !facingRight;
        t.Rotate(0f, 180f, 0f);
    }

    private void Jump()
    {
        Collider2D collider = Physics2D.OverlapCircle(isGroundedChecker.position, checkGroundRadius, groundLayer);
        if (collider != null)
        {
            isGrounded = true;

            doubleJumpAvaiable = canDoubleJump;
            dashAvaiable = canDashJump;
        }
        else
        {
            if (isGrounded)
            {
                lastTimeGrounded = Time.time;
            }
            isGrounded = false;
        }

        bool grounded = isGrounded || Time.time - lastTimeGrounded <= groundedMemory;


        if (Input.GetKeyUp(KeyCode.S))
        {
            charging = false;
        }

        if (canChargeJump && !charging && Input.GetKey(KeyCode.S))
        {
            charging = true;
            chargeTimer = chargingTime;
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (charging && chargeTimer <= 0 && grounded)
            {
                chargedJump = true;
                charging = false;
            }
            else if (grounded || doubleJumpAvaiable)
            {
                if (!grounded)
                    doubleJumpAvaiable = false;

                jump = true;
                charging = false;
            }
        }

        if (!grounded && canDashJump && dashAvaiable && Input.GetKeyDown(KeyCode.Mouse0))
        {
            dash = true;
            dashAvaiable = false;
        }


        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
        {
            rb.velocity += Vector2.up * Physics2D.gravity * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }

    private void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            //a.SetTrigger("Attack");

            Collider2D[] colliders = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemiesLayer);
            foreach (Collider2D collider in colliders)
            {
                collider.gameObject.SendMessage("Hitted");
            }

        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            //a.SetTrigger("Attack");

            Collider2D[] colliders = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemiesLayer);
            foreach (Collider2D collider in colliders)
            {
                collider.gameObject.SendMessage("Hitted");
            }

        }
    }

    /*public void UnlockAbility(PowerUpController.PowerUp powerUp)
    {
        switch (powerUp)
        {
            case PowerUpController.PowerUp.DoubleJump:
                canDoubleJump = true;
                break;
            case PowerUpController.PowerUp.ChargedJump:
                canChargeJump = true;
                break;
            case PowerUpController.PowerUp.DashJump:
                canDashJump = true;
                break;
        }
    }*/


    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    public void PauseMovement()
    {
        canMove = false;
    }

    public void AllowMovement()
    {
        canMove = true;
    }

}
