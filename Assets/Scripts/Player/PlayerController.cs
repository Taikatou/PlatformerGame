using UnityEngine;

[RequireComponent(typeof(KnockBack))]
public class PlayerController : MonoBehaviour
{
    [HideInInspector]
    private bool FacingRight = true;

    public int PlayerSpeed = 10;
    public float PlayerJumpPower = 1250;
    private float moveX;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;

    private KnockBack _knockBack;

    public AudioSource jumpSound;

    public bool IsGrounded
    {
        get
        {
            bool collider = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
            return collider;
        }
    }

    private void Start()
    {
        _knockBack = gameObject.GetComponent<KnockBack>();
    }

    private void Update()
    {
        if(!(_knockBack && _knockBack.KnockedBack))
        {
            PlayerMove();
        }
    }

    void PlayerMove()
    {
        moveX = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }

        bool FlipRight = moveX > 0.0f && !FacingRight;
        bool FlipLeft = moveX < 0.0f && FacingRight;
        if (FlipRight || FlipLeft)
        {
            FlipPlayer();
        }

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
        if (IsGrounded)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * PlayerJumpPower);
            jumpSound.Play();
        }
    }
}
