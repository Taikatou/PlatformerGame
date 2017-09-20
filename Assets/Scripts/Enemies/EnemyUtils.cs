using UnityEngine;

public class EnemyUtils
{
    public static bool ToRightOf(GameObject self, GameObject other, bool considerDirection = true)
    {
        bool toRightOf = !considerDirection || other.transform.position.x < self.transform.position.x;
        return toRightOf;
    }
}
