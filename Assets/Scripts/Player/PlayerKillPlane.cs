using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKillPlane : KillPlaneDestroyable
{
    public override void Kill()
    {
        LevelManager.Manager.Respawn();
    }
}
