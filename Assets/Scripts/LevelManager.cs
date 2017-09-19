using UnityEngine;
using System.Collections;

public delegate void OnRespawn();

public class LevelManager : MonoBehaviour
{
    public AudioSource CoinSound;

    public void PlayCoinSound()
    {
        CoinSound.Play();
    }

    // Update is called once per frame
    public void Respawn(GameObject gameObject, RespawnAble respawnAble, OnRespawn respawnDelegate)
    {
        StartCoroutine(RespawnCo(gameObject, respawnAble, respawnDelegate));
    }

    public IEnumerator RespawnCo(GameObject gameObject, RespawnAble respawnAble, OnRespawn respawnDelegate)
    {
        gameObject.SetActive(false);

        if(respawnAble.respawnEffect)
        {
            Instantiate(respawnAble.respawnEffect, gameObject.transform.position, gameObject.transform.rotation);
        }

        yield return new WaitForSeconds(respawnAble.respawnTime);

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
}
