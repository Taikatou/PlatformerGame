using Interfaces;
using System.Collections.Generic;
using UnityEngine;

public delegate void UpdateLife(int lifes);

public class PlayerLife : MonoBehaviour, IRespawn
{
    public int maxhealth = 3;
    private int _life = 3;
    public int Life
    {
        get
        {
            return _life;
        }
        set
        {
            _life = value;
            UpdateLifeDelegates();
            if (_life <= 0)
            {
                LevelManager.Manager.Respawn();
            }
        }
    }

    private List<UpdateLife> _lifeDelegates;
    public List<UpdateLife> LifeDelegates
    {
        get
        {
            if(_lifeDelegates == null)
            {
                _lifeDelegates = new List<UpdateLife>();
            }
            return _lifeDelegates;
        }
    }

    public void AddLifeDeletate(UpdateLife lifeDelegate)
    {
        LifeDelegates.Add(lifeDelegate);
        lifeDelegate.Invoke(Life);
    }

    public void UpdateLifeDelegates()
    {
        foreach(UpdateLife toUpdate in LifeDelegates)
        {
            toUpdate.Invoke(Life);
        }
    }

    void ResetLife()
    {
        Life = maxhealth;
    }

    void Start()
    {
        ResetLife();
    }

    public void Respawn()
    {
        RespawnAble respawnAble = gameObject.GetComponent<RespawnAble>();
        if (respawnAble)
        {
            ResetLife();
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
