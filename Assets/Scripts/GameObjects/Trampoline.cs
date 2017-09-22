using UnityEngine;

public class Trampoline : MonoBehaviour
{
    public float JumpPower = 100;

    public AudioSource jumpSound;

    private void OnCollisionEnter2D(Collision2D other)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up);
        if (hit.collider && hit.collider.tag == "Player")
        {
            other.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * JumpPower);
            if (jumpSound)
            {
                jumpSound.Play();
            }
        }
    }
}
