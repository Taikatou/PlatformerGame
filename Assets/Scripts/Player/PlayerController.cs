using UnityEngine;

[RequireComponent(typeof(KnockBack))]
[RequireComponent(typeof(MovementSpeed))]
public class PlayerController : MonoBehaviour
{
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

        Rigidbody2D rigidBody = gameObject.GetComponent<Rigidbody2D>();
        _movementSpeed.ModifySpeed(moveX);
        rigidBody.velocity = new Vector2(_movementSpeed.Speed, rigidBody.velocity.y);
    }
}
