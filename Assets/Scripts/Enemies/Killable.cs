using UnityEngine;

public class Killable : MonoBehaviour
{
    public float maxLife = 1;
    private float currentLife;
    // Use this for initialization
    void Start()
    {
        currentLife = maxLife;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        GameObject otherGO = other.gameObject;
        HurtPlayer hPlayer = gameObject.GetComponent<HurtPlayer>();
        if(otherGO.tag == "Player" && !(hPlayer && hPlayer.hurtplayer))
        {
            currentLife--;
            if(currentLife <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
