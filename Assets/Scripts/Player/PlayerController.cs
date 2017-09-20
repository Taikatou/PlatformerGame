using UnityEngine;

[RequireComponent(typeof(KnockBack))]
[RequireComponent(typeof(GroundChecker))]
[RequireComponent(typeof(MovementSpeed))]
public class PlayerController : MonoBehaviour
{
    [HideInInspector]
    private bool FacingRight = true;

    public float PlayerJumpPower = 1250;

    private KnockBack _knockBack;

    public AudioSource jumpSound;

    private GroundChecker _groundChecker;

    private bool OnPlatform;

    private MovementSpeed _movementSpeed;

    private void Start()
    {
        _knockBack = gameObject.GetComponent<KnockBack>();
        _groundChecker = gameObject.GetComponent<GroundChecker>();
        _movementSpeed = gameObject.GetComponent<MovementSpeed>();
    }

    private void Update()
    {
        if(!(_knockBack && _knockBack.KnockedBack))
        {
            PlayerMove();
        }
    }

    private void PlayerMove()
    {
        float moveX = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }

        bool flipRight = moveX > 0.0f && !FacingRight;
        bool flipLeft = moveX < 0.0f && FacingRight;
        if (flipRight || flipLeft)
        {
            FlipPlayer();
        }

        Rigidbody2D rigidBody = gameObject.GetComponent<Rigidbody2D>();
        _movementSpeed.ModifySpeed(moveX);
        rigidBody.velocity = new Vector2(_movementSpeed.Speed, rigidBody.velocity.y);
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
        if (_groundChecker.IsGrounded)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * PlayerJumpPower);
            jumpSound.Play();
        }
    }
}
