using Interfaces;
using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour, IRespawn {

    public float waitToRespawn;
	
	// Update is called once per frame
	public void Respawn ()
    {
        StartCoroutine("RespawnCo");
    }

    public IEnumerator RespawnCo()
    {
        PlayerLife player = PlayerLife.StaticLife;
        player.gameObject.SetActive(false);
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
}
