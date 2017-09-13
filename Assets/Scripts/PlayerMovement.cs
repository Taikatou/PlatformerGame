using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int PlayerSpeed = 10;
    private bool FacingRight = true;
    public float PlayerJumpPower = 1250;
    private float moveX;

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
        gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * PlayerJumpPower);
    }
}
