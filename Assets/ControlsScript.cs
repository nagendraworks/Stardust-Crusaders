using System.Collections;
using UnityEngine;

public class ControlsScript : MonoBehaviour
{
    public Rigidbody2D rb;

    public Transform groundCheck;
    public LayerMask groundLayer;
    public TrailRenderer tr;
    public float jumpForce = 10f;
    public float fallMultiplier = 2.5f;
    private float Move;
    public float Speed = 5f;

    private bool canDash = true;
    private bool isDashing;
    public float dashingPower = 24f;
    public float dashingTime = 0.2f;
    public float dashCooldown = 1f;

    Vector2 vecGravity;

    void Start()
    {
        vecGravity = new Vector2(0, -Physics2D.gravity.y);
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isDashing)
        {
            return;
        }

        // Horizontal movement
        Move = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(Move * Speed, rb.linearVelocity.y);

        // Flip sprite based on movement direction
        if (Move > 0)
        {
            // Facing right
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (Move < 0)
        {
            
            transform.localScale = new Vector3(1, 1, 1);// Facing left
        }

        // Jump logic
        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded())
        {
            rb.linearVelocity = Vector2.up * jumpForce;
        }

        // Fall multiplier for smoother falling
        if (rb.linearVelocity.y < 0)
        {
            rb.linearVelocity -= vecGravity * fallMultiplier * Time.deltaTime;
        }

        // Dash logic
        if (Input.GetKeyDown(KeyCode.Space) && canDash)
        {
            StartCoroutine(Dash());
        }
    }

    bool isGrounded()
    {
        return Physics2D.OverlapCapsule(groundCheck.position, new Vector2(1.8f, 0.3f), CapsuleDirection2D.Horizontal, 0, groundLayer);
    }


   private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0;

        // Invert the dash direction: if facing left (localScale.x is negative), dash right (positive direction)
        Vector2 dashDirection = new Vector2(-Mathf.Sign(transform.localScale.x), 0).normalized;

        // Apply the dash velocity in the inverted direction
        rb.linearVelocity = dashDirection * dashingPower;

        // Enable trail effect
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);

        // Reset dashing state
        tr.emitting = false;
        rb.gravityScale = originalGravity;
        isDashing = false;

        // Dash cooldown
        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }

}


// using System.Collections;
// using UnityEngine;

// public class ControlsScript : MonoBehaviour
// {
//     public Rigidbody2D rb;
//     //public float flapstrength;
//     public SpriteRenderer spriteRenderer;
//     public Transform groundCheck;
//     public LayerMask groundLayer;
//     public TrailRenderer tr;
//     public float jumpForce = 10;
//     public float fallMultiplier;
//     private float Move;
//     public float Speed;


//     private bool canDash = true;
//     private bool isDashing;
//     public float dashingPower =24f;

//     public float dashingTime = 0.2f;
//     public float dashCooldown = 1f;

//     Vector2 vecGravity;
//     void Start()
//     {
//         vecGravity= new Vector2(0, -Physics2D.gravity.y);
//         rb = GetComponent<Rigidbody2D>();
//     }

//     void Update()
//     {
//         if(isDashing)
//         {
//             return;
//         }
//         Move = Input.GetAxis("Horizontal");
//         rb.linearVelocity = new Vector2(Move * Speed, rb.linearVelocity.y);

//         if (Move > 0) // Moving right
//         {
//             spriteRenderer.flipX = false; // Ensure the sprite is facing right
//         }
//         else if (Move < 0) // Moving left
//         {
//             spriteRenderer.flipX = true; // Flip the sprite to face left
//         }

//         if(Input.GetKeyDown(KeyCode.Space) && canDash)
//         {
//             StartCoroutine(Dash());
//         }

//         //if (Input.GetKeyDown(KeyCode.RightArrow)) // If the right arrow key is pressed
//         //{
//         //    rb.linearVelocity = Vector2.right * flapstrength;
//         //    spriteRenderer.flipX = false;
//         //}

//         //if (Input.GetKeyDown(KeyCode.LeftArrow)) // If the left arrow key is pressed
//         //{
//         //    rb.linearVelocity = Vector2.left * flapstrength;
//         //    spriteRenderer.flipX = true;
//         //}

//         if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded() )// If the space key is pressed and not currently jumping
//         {
//             rb.linearVelocity = Vector2.up * jumpForce; // Apply jump force
//              // Set jumping state to true
//              // Start coroutine to reset jumping state after a delay
//         }

//         if(rb.linearVelocity.y<0)
//         {
//             rb.linearVelocity -= vecGravity * fallMultiplier * Time.deltaTime;
//         }
//     }
//     bool isGrounded()
//     {
//         return Physics2D.OverlapCapsule(groundCheck.position, new Vector2(1.8f, 0.3f), CapsuleDirection2D.Horizontal, 0, groundLayer);

//     }
//     private IEnumerator Dash()
//     {
//         canDash = false;
//         isDashing = true;
//         float originalGravity = rb.gravityScale;
//         rb.gravityScale = 0;
//         rb.linearVelocity = new Vector2(transform.localScale.x * dashingPower ,0);
//         tr.emitting = true;
//         yield return new WaitForSeconds(dashingTime);
//         tr.emitting = false;
//         rb.gravityScale = originalGravity;
//         isDashing = false;
//         yield return new WaitForSeconds(dashCooldown);
//         canDash = true;


//     }


// }
