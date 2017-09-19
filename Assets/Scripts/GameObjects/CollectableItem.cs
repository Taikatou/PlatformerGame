using Interfaces;
using UnityEngine;

[RequireComponent(typeof(PlayerStats))]
public class CollectableItem : MonoBehaviour, IResetAble
{
    public int Value = 1;

    public void Destroy()
    {
        Destroy(gameObject);
    }

    public void Reset(PlayerStats stats)
    {
        gameObject.SetActive(true);
        stats.RemoveCoin(Value);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            PlayerStats stats = other.GetComponent<PlayerStats>();
            stats.AddCoin(Value);
            stats.AddResetAble(this);
            LevelManager.Manager.PlayCoinSound();
            gameObject.SetActive(false);
        }
    }
}
