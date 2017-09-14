using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [HideInInspector]
    private bool FacingRight = true;

    public int PlayerSpeed = 10;
    public float PlayerJumpPower = 1250;
    private float moveX;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;

    public bool IsGrounded
    {
        get
        {
            bool collider = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
            return collider;
        }
    }

	void Update ()
    {
        PlayerMove();
	}

    void PlayerMove()
    {
        // Controls
        moveX = Input.GetAxis("Horizontal");
        if(Input.GetButtonDown("Jump"))
        {
            Jump();
        }

        // Animation

        // Player Direction
        bool FlipRight = moveX > 0.0f && !FacingRight;
        bool FlipLeft = moveX < 0.0f && FacingRight;
        if (FlipRight || FlipLeft)
        {
            FlipPlayer();
        }

        // Physics
        Rigidbody2D rigidBody = gameObject.GetComponent<Rigidbody2D>();
        rigidBody.velocity = new Vector2(moveX * PlayerSpeed, rigidBody.velocity.y);
    }

    void FlipPlayer()
    {
        FacingRight = !FacingRight;
        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    void Jump()
    {
        if(IsGrounded)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * PlayerJumpPower);
        }
    }
}
