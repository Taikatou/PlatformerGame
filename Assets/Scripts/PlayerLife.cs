using Interfaces;
using UnityEngine;

public class PlayerLife : MonoBehaviour, IRespawn
{
    private int _life = 1;
    public int Life
    {
        get
        {
            return _life;
        }
        set
        {
            _life = value;
            if(_life <= 0)
            {
                LevelManager.Manager.Respawn();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "KillPlane")
        {
            LevelManager.Manager.Respawn();
        }
    }

    public void Respawn()
    {
        RespawnAble respawnAble = gameObject.GetComponent<RespawnAble>();
        if (respawnAble)
        {
            transform.position = respawnAble.RespawnPosition;
        }
    }

    public void HurtPlayer(int damage)
    {
        Life -= damage;
    }

    public void HealPlayer(int healBy)
    {
        Life += healBy;
    }

    public static PlayerLife StaticLife
    {
        get
        {
            PlayerLife player = FindObjectOfType<PlayerLife>();
            return player;
        }
    }
}
