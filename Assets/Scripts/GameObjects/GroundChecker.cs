using UnityEngine;

public class GroundChecker : MonoBehaviour
{
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
}
