using UnityEngine;

public class EndOfLevel : CheckPointController
{
    public int LevelId;

    public override void CheckCollision(RaycastHit2D hit)
    {
        bool isPlayer = CheckIfPlayer(hit);
        LoadScene loader = GetComponent<LoadScene>();
        if(isPlayer)
        {
            loader.Load(LevelId);
        }
    }
}
