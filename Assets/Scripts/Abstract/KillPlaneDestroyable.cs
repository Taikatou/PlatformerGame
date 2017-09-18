using UnityEngine;

public abstract class KillPlaneDestroyable : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "KillPlane")
        {
            Kill();
        }
    }

    public abstract void Kill();
}
