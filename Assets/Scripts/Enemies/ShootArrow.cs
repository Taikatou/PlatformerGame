using UnityEngine;

public class ShootArrow : MonoBehaviour
{
    public Transform SpawnLocation;
    public GameObject ArrowObject;

    public void Shoot()
    {
        Instantiate(ArrowObject, SpawnLocation.position, SpawnLocation.rotation);
    }
}
