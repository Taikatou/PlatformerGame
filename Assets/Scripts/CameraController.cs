using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject target;

	// Use this for initialization
	private void Start ()
    {
		
	}
	
	// Update is called once per frame
	private void Update ()
    {
        Vector3 position = target.transform.position;
        transform.position = new Vector3(position.x, transform.position.y, transform.position.z);
	}
}
