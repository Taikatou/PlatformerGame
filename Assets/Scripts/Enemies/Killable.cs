using UnityEngine;

[RequireComponent(typeof(HurtPlayer))]
[RequireComponent(typeof(GroundChecker))]
public class Killable : MonoBehaviour
{
    public float maxLife = 1;
    private float currentLife;

    public float bounceForce = 3.0f;

    private void Start()
    {
        currentLife = maxLife;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        GameObject otherGO = other.gameObject;
        HurtPlayer hPlayer = gameObject.GetComponent<HurtPlayer>();
        GroundChecker groundChecker = otherGO.GetComponent<GroundChecker>();
        if (otherGO.tag == "Player" && !((hPlayer && hPlayer.hurtplayer) || groundChecker.IsGrounded))
        {
            currentLife--;
            if(currentLife <= 0)
            {
                HandleDeath(other);
            }
        }
    }

    public virtual void HandleDeath(Collision2D player)
    {
        Rigidbody2D playerRB = player.collider.GetComponent<Rigidbody2D>();
        playerRB.velocity = new Vector3(playerRB.velocity.x, bounceForce, 0.0f);

        RespawnAble.TestRespawnable(gameObject);
    }
}
