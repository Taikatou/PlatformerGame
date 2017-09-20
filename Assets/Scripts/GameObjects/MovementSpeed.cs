using UnityEngine;

public class MovementSpeed : MonoBehaviour
{
    public float MaxSpeedNormal = 10.0f;

    public float MaxSpeedOnPlatform = 6.0f;

    public bool OnPlatform = false;

    public float MaxSpeed
    {
        get
        {
            return OnPlatform ? MaxSpeedOnPlatform : MaxSpeedNormal;
        }
    }

    public float LerpScale = 0.1f;

    private float _currentSpeed = 0.0f;

    public float Speed
    {
        get
        {
            return _currentSpeed;
        }
    }

    public void ModifySpeed(float scale)
    {
        _currentSpeed = Mathf.Lerp(_currentSpeed, MaxSpeed * scale, LerpScale);
    }
}