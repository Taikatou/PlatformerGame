using UnityEngine;

public class CollectableItem : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            LevelManager.Manager.AddCoin();
            Destroy(gameObject);
        }
    }
}
