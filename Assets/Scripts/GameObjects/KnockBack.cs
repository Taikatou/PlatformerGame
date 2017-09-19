using UnityEngine;

public class KnockBack : MonoBehaviour {

    public float KnockBackTime = 1.0f;
    public float KnockBackForce = 5.0f;
    private float _knockBackCountDown;

    public bool KnockedBack
    {
        get
        {
            return _knockBackCountDown > 0;
        }
    }

    public void Knock(GameObject other)
    {
        _knockBackCountDown = KnockBackTime;
        Rigidbody2D rigidBody = gameObject.GetComponent<Rigidbody2D>();
        rigidBody.velocity = GetKnockBackVelocity(other.transform.position,
                                                  transform.position);
    }
    
    public Vector2 GetKnockBackVelocity(Vector3 otherPosition, Vector3 goPosition)
    {
        bool above = otherPosition.y > goPosition.y;
        bool toRightOf = otherPosition.x > goPosition.x;
        float forceX = GetStrength(toRightOf);
        float forceY = GetStrength(above);
        return new Vector2(forceX, forceY);
    }

    public float GetStrength(bool positive)
    {
        // Push in opposite direction
        return positive ? -KnockBackForce : KnockBackForce;
    }

    private void Update()
    {
        if (KnockedBack)
        {
            _knockBackCountDown -= Time.deltaTime;
        }
    }
}
