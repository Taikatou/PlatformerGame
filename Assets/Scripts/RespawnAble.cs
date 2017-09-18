using UnityEngine;

public class RespawnAble : MonoBehaviour {
    [HideInInspector]
    public bool _set;
    [HideInInspector]
    public Vector3 _position;

    public GameObject respawnEffect;

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

    public static void TestRespawnable(GameObject gameObject, bool ignoreDestroy = false)
    {
        RespawnAble respawnAble = gameObject.GetComponent<RespawnAble>();
        if (respawnAble)
        {
            LevelManager.Manager.Respawn(gameObject, respawnAble.OnRespawn, respawnAble.respawnEffect);
        }
        else if(!ignoreDestroy)
        {
            Destroy(gameObject);
        }
    }
}
