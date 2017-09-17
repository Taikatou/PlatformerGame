using UnityEngine;

public class RespawnAble : MonoBehaviour
{
    private bool _set;
    private Vector3 _position;

    public Vector3 RespawnPosition
    {
        get
        {
            return _position;
        }
    }

    private void Start()
    {
        _position = transform.position;
        Debug.Log("Start");
    }

    public virtual void PassCheckPoint(Vector3 position)
    {
        if (!_set || position.x > _position.x)
        {
            _set = true;
            _position = position;
        }
    }
}
