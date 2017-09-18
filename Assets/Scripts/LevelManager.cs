using Interfaces;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelManager : MonoBehaviour, IRespawn
{
    public Text coinText;

    public float waitToRespawn;
    public GameObject DeathParticleEffect;

    private int _coinCount;
    public int CoinCount
    {
        get
        {
            return _coinCount;
        }
        set
        {
            _coinCount = value;
            coinText.text = "Coins: " + CoinCount;
        }
    }
    private void Start()
    {
        CoinCount = 0;
    }

    // Update is called once per frame
    public void Respawn ()
    {
        StartCoroutine("RespawnCo");
    }

    public IEnumerator RespawnCo()
    {
        PlayerLife player = PlayerLife.StaticLife;
        player.gameObject.SetActive(false);

        Instantiate(DeathParticleEffect, player.transform.position, player.transform.rotation);

        yield return new WaitForSeconds(waitToRespawn);

        player.Respawn();
        player.gameObject.SetActive(true);
    }

    public static LevelManager Manager
    {
        get
        {
            return FindObjectOfType<LevelManager>();
        }
    }

    public void AddCoin(int coinNum = 1)
    {
        CoinCount += coinNum;
    }
}
