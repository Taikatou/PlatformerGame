public class PlayerKillPlane : KillPlaneDestroyable
{
    public override void Kill()
    {
        LevelManager.Manager.Respawn();
    }
}
