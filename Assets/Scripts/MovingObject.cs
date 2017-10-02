using UnityEngine;

public class MovingObject : MonoBehaviour {
    public GameObject movingObject;

    public Transform startPoint;
    public Transform endPoint;

    public float moveSpeed = 1.0f;

    public bool MovingToEnd = true;

    public bool ConsiderX = true;

    public bool ConsiderY = false;

 

    private Vector3 CurrentTarget
    {
        get
        {
            Transform currentTarget = MovingToEnd ? endPoint : startPoint;
            return currentTarget.position;
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 position = movingObject.transform.position;
        float speedPerSecond = moveSpeed * Time.deltaTime;
        Vector3 newPosition = Vector3.MoveTowards(position, CurrentTarget, speedPerSecond);
        Rigidbody2D rigidBody = gameObject.GetComponent<Rigidbody2D>();
        Vector3 baseVelocity = (newPosition - position) / Time.deltaTime;
        float xVelocity = ConsiderX ? baseVelocity.x : rigidBody.velocity.x;
        float yVelocity = ConsiderY ? baseVelocity.y : rigidBody.velocity.y;
        rigidBody.velocity = new Vector2(xVelocity, yVelocity);
        CheckEnd();
    }

    void CheckEnd()
    {
        Vector3 position = movingObject.transform.position;
        bool XCorrect = !ConsiderX || MathUtils.IsApproximate(position.x, CurrentTarget.x);
        bool YCorrect = !ConsiderY || MathUtils.IsApproximate(position.y, CurrentTarget.y);
        if (XCorrect && YCorrect)
        {
            MovingToEnd = !MovingToEnd;
        }
    }
}
