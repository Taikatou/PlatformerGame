using UnityEngine;

public class StickToMovingObject : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D other)
    {
        GameObject otherGO = other.gameObject;
        if (IsMovingPlatform(otherGO))
        {
            transform.parent = otherGO.transform;
        }
    }

    bool IsMovingPlatform(GameObject otherGO)
    {
        return otherGO.tag == "MovingObject";
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        GameObject otherGO = other.gameObject;
        if (IsMovingPlatform(otherGO))
        {
            transform.parent = null;
        }
    }
}
