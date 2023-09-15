using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketShootStrategy : BaseShootStrategy
{
    public RocketShootStrategy(PlayerShoot shoot, ObjectPool pool, Material gunMaterial) : base (shoot, pool)
    {
        shoot.gunMeshRenderer.material = gunMaterial;
    }
}
