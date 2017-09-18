public class EnemyKillPlaneBehaviour : KillPlaneDestroyable
{
    public override void Kill()
    {
        Destroy(gameObject);
    }
}
