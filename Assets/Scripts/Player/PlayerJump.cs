using UnityEngine;

[RequireComponent(typeof(GroundChecker))]
public class PlayerJump : MonoBehaviour
{
    private GroundChecker _groundChecker;

    public float PlayerJumpPower = 1250;

    public AudioSource jumpSound;

    private bool _ignoreGroundCheck = false;

    public void IgnoreGround()
    {
        _ignoreGroundCheck = true;
    }

    private void Start()
    {
        _groundChecker = gameObject.GetComponent<GroundChecker>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (_groundChecker.IsGrounded || _ignoreGroundCheck)
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
        if(_ignoreGroundCheck && _groundChecker.IsGrounded)
        {
            _ignoreGroundCheck = false;
        }
    }
}
