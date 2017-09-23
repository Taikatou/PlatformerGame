using UnityEngine;

[RequireComponent(typeof(GroundChecker))]
public class PlayerJump : MonoBehaviour
{
    private GroundChecker _groundChecker;

    public float PlayerJumpPower = 1250;

    public AudioSource jumpSound;

    private bool IgnoreGroundCheck = false;

    public void IgnoreGround()
    {
        IgnoreGroundCheck = true;
    }

    private void Start()
    {
        _groundChecker = gameObject.GetComponent<GroundChecker>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (_groundChecker.IsGrounded || IgnoreGroundCheck)
            {
                Jump(PlayerJumpPower);
            }
        }
    }

    public void Jump(float Force)
    {
        Vector2 JumpForce = Vector2.up * Force;
        gameObject.GetComponent<Rigidbody2D>().AddForce(JumpForce);
        jumpSound.Play();
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if(IgnoreGroundCheck && _groundChecker.IsGrounded)
        {
            IgnoreGroundCheck = false;
        }
    }
}
