using UnityEngine;

public class Trampoline : MonoBehaviour
{
    public float JumpPower = 100;

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        GroundChecker checker = other.gameObject.GetComponent<GroundChecker>();
        if(checker.IsGrounded)
        {
            PlayerJump jumper = other.gameObject.GetComponent<PlayerJump>();
            jumper.Jump(JumpPower);
            jumper.IgnoreGround();
        }
    }
}
