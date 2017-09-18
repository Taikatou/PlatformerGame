using UnityEngine;

public class MovingObject : MonoBehaviour {
    public GameObject movingObject;

    public Transform startPoint;
    public Transform endPoint;

    public float moveSpeed = 1.0f;

    public bool MovingToEnd = true;

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
        movingObject.transform.position = newPosition;
        CheckEnd();
    }

    void CheckEnd()
    {
        Vector3 position = movingObject.transform.position;
        if (position == CurrentTarget)
        {
            MovingToEnd = !MovingToEnd;
        }
    }
}
