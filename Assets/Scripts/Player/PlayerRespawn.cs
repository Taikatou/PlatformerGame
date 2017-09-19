using UnityEngine;

[RequireComponent(typeof(PlayerStats))]
[RequireComponent(typeof(PlayerLife))]
public class PlayerRespawn : RespawnAble
{
    public virtual void PassCheckPoint(Vector3 position)
    {
        if (!_set || position.x > _position.x)
        {
            _set = true;
            _position = position;
        }
        PlayerStats playerStats = gameObject.GetComponent<PlayerStats>();
        if (playerStats)
        {
            playerStats.CheckPoint();
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
        PlayerStats playerStats = gameObject.GetComponent<PlayerStats>();
        if(playerStats)
        {
            playerStats.Reset();
        }
    }
}
