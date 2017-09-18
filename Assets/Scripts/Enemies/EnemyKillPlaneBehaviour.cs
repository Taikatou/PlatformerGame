public class EnemyKillPlaneBehaviour : KillPlaneDestroyable
{
    public override void Kill()
    {
        RespawnAble shouldRespawn = gameObject.GetComponent<RespawnAble>();
        if(shouldRespawn)
        {

        }
        else
        {
            Destroy(gameObject);
        }
    }
}
