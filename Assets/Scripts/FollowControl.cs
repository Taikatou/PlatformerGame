using UnityEngine;

public class FollowControl : MonoBehaviour
{
    public GameObject follower;
    public GameObject target;
    public float followAhead;
    public float smoothing;

    public bool moveY = false;
    public bool includeTime = true;

	// Update is called once per frame
	private void Update ()
    {
        bool movingLeft = target.transform.localScale.x > 0f;
        float localFollowAhead = movingLeft? followAhead : -followAhead;
        float yMovement = moveY ? target.transform.position.y : follower.transform.position.y;
        Vector3 targetPosition = new Vector3(target.transform.position.x + localFollowAhead,
                                             yMovement,
                                             follower.transform.position.z);

        float smooth = includeTime ? smoothing * Time.deltaTime : smoothing;
        follower.transform.position = Vector3.Lerp(follower.transform.position, targetPosition, smooth);
	}
}
