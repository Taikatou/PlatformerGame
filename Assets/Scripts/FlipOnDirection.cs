using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class FlipOnDirection : MonoBehaviour
{
    private Rigidbody2D rigidBody;

    public bool StartFacingRight = true;

    private bool _facingCorrect;

    void Start ()
    {
        rigidBody = gameObject.GetComponent<Rigidbody2D>();
        _facingCorrect = StartFacingRight;
    }
	
	// Update is called once per frame
	void Update ()
    {
        float moveRight = rigidBody.velocity.x;
        bool flipRight = moveRight > 0.0f && !_facingCorrect;
        bool flipLeft = moveRight < 0.0f && _facingCorrect;
        if (flipRight || flipLeft)
        {
            Flip();
        }
    }

    private void Flip()
    {
        _facingCorrect = !_facingCorrect;
        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
}
