public class EnemyKillPlaneBehaviour : KillPlaneDestroyable
{
    public override void Kill()
    {
        RespawnAble shouldRespawn = gameObject.GetComponent<RespawnAble>();
        if(shouldRespawn)
        {
            LevelManager.Manager.Respawn(gameObject, shouldRespawn, shouldRespawn.OnRespawn);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
