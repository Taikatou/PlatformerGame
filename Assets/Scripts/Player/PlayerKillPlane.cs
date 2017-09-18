public class PlayerKillPlane : KillPlaneDestroyable
{
    public override void Kill()
    {
        RespawnAble respawnAble = gameObject.GetComponent<RespawnAble>();
        respawnAble.Respawn();
    }
}
