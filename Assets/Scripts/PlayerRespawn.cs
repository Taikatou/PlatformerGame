using UnityEngine;

public class PlayerRespawn : RespawnAble
{
    public virtual void PassCheckPoint(Vector3 position)
    {
        if (!_set || position.x > _position.x)
        {
            _set = true;
            _position = position;
        }
    }

    public override void OnRespawn()
    {
        base.OnRespawn();
        PlayerLife playerLife = gameObject.GetComponent<PlayerLife>();
        if (playerLife)
        {
            playerLife.ResetLife();
        }
    }
}
