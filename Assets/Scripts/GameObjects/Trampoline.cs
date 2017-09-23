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
        if(other.gameObject.transform.position.y > gameObject.transform.position.y)
        {
            PlayerJump jumper = other.gameObject.GetComponent<PlayerJump>();
            jumper.Jump(JumpPower);
            jumper.IgnoreGround();
        }
    }
}
