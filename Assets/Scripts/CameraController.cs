using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject target;
    public float followAhead;
    public float smoothing;

	// Use this for initialization
	private void Start ()
    {
		
	}
	
	// Update is called once per frame
	private void Update ()
    {
        Vector3 position = target.transform.position;
        bool movingLeft = target.transform.localScale.x > 0f;
        float localFollowAhead = movingLeft? followAhead : -followAhead;
        Vector3 targetPosition = new Vector3(position.x + localFollowAhead,
                                             transform.position.y,
                                             transform.position.z);

        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing * Time.deltaTime);
	}
}
