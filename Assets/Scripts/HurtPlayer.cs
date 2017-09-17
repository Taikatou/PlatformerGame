using UnityEngine;

public class HurtPlayer : MonoBehaviour
{
    public int DamageBy = 1;

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            PlayerLife.StaticLife.HurtPlayer(DamageBy);
        }
    }
}
