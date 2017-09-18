using UnityEngine;

public class SnakeController : MonoBehaviour
{
    public float moveSpeed;
    private bool canMove;

    public Rigidbody2D rigidBody
    {
        get
        {
            return GetComponent<Rigidbody2D>();
        }
    }

    // Update is called once per frame
    private void Update ()
    {
		if(canMove)
        {
            Vector2 velocity = rigidBody.velocity;
            rigidBody.velocity = new Vector3(-moveSpeed, velocity.y, 0f);
        }
	}

    private void OnBecameVisible()
    {
        canMove = true;
    }
}
