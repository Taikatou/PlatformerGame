using UnityEngine;

public class CheckPointController : MonoBehaviour
{
    public Sprite flagClosed;
    public Sprite flagOpen;
    public bool traceUp = true;
    public bool traceDown = false;
    public bool openOnce = true;

    private bool _open = false;

    private SpriteRenderer spriteRenderer
    {
        get
        {
            return GetComponent<SpriteRenderer>();
        }
    }

    void Update()
    {
        if(!_open || !openOnce)
        {
            ConditionTrace(traceUp, Vector2.up);
            ConditionTrace(traceDown, -Vector2.up);
        }
    }

    void ConditionTrace(bool condition, Vector2 direction)
    {
        if(condition)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, direction);
            if (hit.collider != null)
            {
                CheckCollision(hit);
            }
        }
    }

    void CheckCollision(RaycastHit2D hit)
    {
        if (hit.collider.tag == "Player")
        {
            _open = !_open;
            spriteRenderer.sprite = _open ? flagOpen : flagClosed;

            PlayerRespawn respawnAble = hit.collider.GetComponent<PlayerRespawn>();
            if (respawnAble)
            {
                respawnAble.PassCheckPoint(transform.position);
            }
        }
    }
}
