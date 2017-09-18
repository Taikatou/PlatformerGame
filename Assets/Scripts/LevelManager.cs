using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public delegate void OnRespawn();

public class LevelManager : MonoBehaviour
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
    public void Respawn(GameObject gameObject, OnRespawn respawnDelegate)
    {
        StartCoroutine(RespawnCo(gameObject, respawnDelegate));
    }

    public IEnumerator RespawnCo(GameObject gameObject, OnRespawn respawnDelegate)
    {
        gameObject.SetActive(false);

        Instantiate(DeathParticleEffect, gameObject.transform.position, gameObject.transform.rotation);

        yield return new WaitForSeconds(waitToRespawn);

        respawnDelegate.Invoke();
        gameObject.SetActive(true);
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
