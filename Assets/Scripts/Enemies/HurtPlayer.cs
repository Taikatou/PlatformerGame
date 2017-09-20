using UnityEngine;

public class HurtPlayer : MonoBehaviour
{
    public int DamageBy = 1;
    public float hurtEveryXSecond = 1.0f;

    private float countDown;
    public bool hurtplayer { get; private set; }

    public bool knockBack = true;

    public bool ConsiderDirection = false;

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D other)
    {
        bool toRightOf = EnemyUtils.ToRightOf(gameObject, other.gameObject, ConsiderDirection);
        hurtplayer = GetHurtPlayer(other) && toRightOf;
        if(hurtplayer)
        {
            ActivateHurt();
        }
    }

    private void Update()
    {
        if (hurtplayer)
        {
            PlayerLife Player = PlayerLife.StaticLife;
            if (countDown <= 0 && Player)
            {
                ActivateHurt();
            }
            else
            {
                countDown -= Time.deltaTime;
            }
            if(knockBack)
            {
                KnockBack knockBack = Player.GetComponent<KnockBack>();
                knockBack.Knock(gameObject);
            }
        }
    }

    public void ActivateHurt()
    {
        PlayerLife.StaticLife.HurtPlayer(gameObject, DamageBy);
        countDown = hurtEveryXSecond;
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
