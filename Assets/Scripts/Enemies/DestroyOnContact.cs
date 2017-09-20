using UnityEngine;

public class DestroyOnContact : MonoBehaviour
{
    public bool ConsiderDirection = true;
    private void OnTriggerEnter2D(Collider2D other)
    {
        bool considerDestroy = EnemyUtils.ToRightOf(gameObject, other.gameObject, ConsiderDirection);
        if(considerDestroy)
        {
            Destroy(gameObject);
        }
	}
}
