using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootEye : MonoBehaviour {

	public void Shoot()
    {
        ShootArrow shoot = gameObject.GetComponent<ShootArrow>();
        shoot.Shoot();
    }
}
