using UnityEngine;

public class RespawnAble : MonoBehaviour {
    [HideInInspector]
    public bool _set;
    [HideInInspector]
    public Vector3 _position;

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
    }

    public virtual void OnRespawn()
    {
        transform.position = RespawnPosition;
    }

    public void Respawn()
    {
        LevelManager.Manager.Respawn(gameObject, OnRespawn);
    }
}
