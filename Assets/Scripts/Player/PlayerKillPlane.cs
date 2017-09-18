public class PlayerKillPlane : KillPlaneDestroyable
{
    public override void Kill()
    {
        RespawnAble.TestRespawnable(gameObject, true);
    }
}
