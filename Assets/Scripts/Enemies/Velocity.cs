using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Velocity : MonoBehaviour
{
    public float Speed = 4.0f;
    public bool MoveLeft = true;
	void Start ()
    {
        Rigidbody2D rigidBody = gameObject.GetComponent<Rigidbody2D>();
        rigidBody.velocity = MoveLeft? new Vector2(-Speed, 0): new Vector2(Speed, 0);
    }
}
