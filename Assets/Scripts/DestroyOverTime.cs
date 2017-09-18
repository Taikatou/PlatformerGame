using UnityEngine;

public class DestroyOverTime : MonoBehaviour
{
    public float LifeTime = 1.0f;
	
	// Update is called once per frame
	void Update ()
    {
        LifeTime -= Time.deltaTime;
        if(LifeTime <= 0)
        {
            Destroy(gameObject);
        }
	}
}
