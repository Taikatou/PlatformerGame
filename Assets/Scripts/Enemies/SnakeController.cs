using UnityEngine;

[RequireComponent(typeof(MovementSpeed))]
public class SnakeController : MonoBehaviour
{
    private bool canMove;

    private MovementSpeed _movementSpeed;

    public bool MoveLeft = true;

    private int Direction
    {
        get
        {
            return MoveLeft? -1: 1;
        }
    }

    public Rigidbody2D rigidBody
    {
        get
        {
            return GetComponent<Rigidbody2D>();
        }
    }

    private void Start()
    {
        _movementSpeed = gameObject.GetComponent<MovementSpeed>();
    }

    // Update is called once per frame
    private void Update ()
    {
		if(canMove)
        {
            Vector2 velocity = rigidBody.velocity;
            _movementSpeed.ModifySpeed(Direction);
            rigidBody.velocity = new Vector3(_movementSpeed.Speed, velocity.y, 0f);
        }
	}

    private void OnBecameVisible()
    {
        canMove = true;
    }
}
