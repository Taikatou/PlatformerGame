using UnityEngine;

public class StickToMovingObject : MonoBehaviour
{

    bool IsMovingPlatform(GameObject otherGO)
    {
        return otherGO.tag == "MovingObject";
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        GameObject otherGO = other.gameObject;
        if (IsMovingPlatform(otherGO))
        {
            transform.parent = otherGO.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        GameObject otherGO = other.gameObject;
        if (IsMovingPlatform(otherGO) && other.gameObject.activeSelf)
        {
            transform.parent = null;
        }
    }
}
