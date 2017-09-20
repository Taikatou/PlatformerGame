using UnityEngine;

[RequireComponent(typeof(MovementSpeed))]
public class StickToMovingObject : MonoBehaviour
{
    private MovementSpeed _movementSpeed;

    private void Start()
    {
        _movementSpeed = gameObject.GetComponent<MovementSpeed>();
    }

    bool IsMovingPlatform(GameObject otherGo)
    {
        return otherGo.tag == "MovingObject";
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        GameObject otherGo = other.gameObject;
        if (IsMovingPlatform(otherGo))
        {
            transform.parent = otherGo.transform;
            _movementSpeed.OnPlatform = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        GameObject otherGo = other.gameObject;
        if (IsMovingPlatform(otherGo) && other.gameObject.activeSelf)
        {
            transform.parent = null;
            _movementSpeed.OnPlatform = false;
        }
    }
}
