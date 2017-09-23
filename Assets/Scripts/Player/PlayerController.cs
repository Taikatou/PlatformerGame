using UnityEngine;

[RequireComponent(typeof(KnockBack))]
[RequireComponent(typeof(MovementSpeed))]
public class PlayerController : MonoBehaviour
{
    private bool _facingRight = true;

    private KnockBack _knockBack;

    private MovementSpeed _movementSpeed;

    private void Start()
    {
        _knockBack = gameObject.GetComponent<KnockBack>();
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

        bool flipRight = moveX > 0.0f && !_facingRight;
        bool flipLeft = moveX < 0.0f && _facingRight;
        if (flipRight || flipLeft)
        {
            FlipPlayer();
        }

        Rigidbody2D rigidBody = gameObject.GetComponent<Rigidbody2D>();
        _movementSpeed.ModifySpeed(moveX);
        rigidBody.velocity = new Vector2(_movementSpeed.Speed, rigidBody.velocity.y);
    }

    private void FlipPlayer()
    {
        _facingRight = !_facingRight;
        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
}
