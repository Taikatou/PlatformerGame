using UnityEngine;

public class MathUtils
{
    public static bool IsApproximate(float a, float b, float tolerance= 0.01f)
    {
        return Mathf.Abs(a - b) < tolerance;
    }
}
