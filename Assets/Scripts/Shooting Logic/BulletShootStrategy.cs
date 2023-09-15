using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShootStrategy : BaseShootStrategy
{
    public BulletShootStrategy(PlayerShoot shoot, ObjectPool pool, Material gunMaterial) : base(shoot, pool)
    {
        shoot.gunMeshRenderer.material = gunMaterial;
    }
}
