using UnityEngine;

public class HurtPlayer : MonoBehaviour
{
    public int DamageBy = 1;
    public float hurtEveryXSecond = 1.0f;

    private float countDown;
    public bool hurtplayer { get; private set; }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D other)
    {
        hurtplayer = GetHurtPlayer(other);
    }

    private void Update()
    {
        if (hurtplayer)
        {
            PlayerLife Player = PlayerLife.StaticLife;
            if (countDown <= 0 && Player)
            {
                PlayerLife.StaticLife.HurtPlayer(gameObject, DamageBy);
                countDown = hurtEveryXSecond;
            }
            else
            {
                countDown -= Time.deltaTime;
            }
            KnockBack knockBack = Player.GetComponent<KnockBack>();
            knockBack.Knock(gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        bool toStop = GetHurtPlayer(other);
        if(toStop)
        {
            hurtplayer = false;
            countDown = 0;
        }
    }

    public bool GetHurtPlayer(Collider2D other)
    {
        return other.tag == "Player";
    }
}
