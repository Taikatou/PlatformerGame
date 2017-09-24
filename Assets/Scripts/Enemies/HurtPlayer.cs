using UnityEngine;

public class HurtPlayer : MonoBehaviour
{
    public int DamageBy = 1;
    public float hurtEveryXSecond = 1.0f;

    private float _hurtCountDown;

    public bool hurtplayer { get; private set; }

    public bool knockBack = true;

    public bool considerDirection = false;

    public float validAfterXSeconds = 1.0f;

    private float _countDown;

    private void Start()
    {
        _countDown = validAfterXSeconds;
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D other)
    {
        bool toRightOf = EnemyUtils.ToRightOf(gameObject, other.gameObject, considerDirection);
        hurtplayer = GetHurtPlayer(other) && toRightOf;
        if(hurtplayer && _hurtCountDown <= 0)
        {
            ActivateHurt();
        }
    }

    private void Update()
    {
        if(_countDown > 0)
        {
            _countDown -= Time.deltaTime;
        }
        else if (hurtplayer)
        {
            UpdateHurt();
        }
    }

    private void UpdateHurt()
    {
        PlayerLife Player = PlayerLife.StaticLife;
        if (_hurtCountDown <= 0 && Player)
        {
            ActivateHurt();
        }
        else
        {
            _hurtCountDown -= Time.deltaTime;
        }
        if (knockBack)
        {
            KnockBack knockBack = Player.GetComponent<KnockBack>();
            knockBack.Knock(gameObject);
        }
    }

    public void ActivateHurt()
    {
        PlayerLife.StaticLife.HurtPlayer(gameObject, DamageBy);
        _hurtCountDown = hurtEveryXSecond;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        bool toStop = GetHurtPlayer(other);
        if(toStop)
        {
            hurtplayer = false;
        }
    }

    public bool GetHurtPlayer(Collider2D other)
    {
        return other.tag == "Player";
    }
}
