using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseShootStrategy : IShootStrategy
{
    public PlayerShoot shoot;  
    public ObjectPool pool;

    Transform shootPoint;

    public BaseShootStrategy(PlayerShoot shoot, ObjectPool pool)
    {
        this.shoot = shoot;
        shootPoint = shoot.GetShootPoint();
        this.pool = pool;
    }

    public void Shoot()
    {
        PooledObject projectile = pool.GetPooledObject();
        Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();

        // Reset the position of the reused bullet
        projectile.transform.position = shootPoint.position;

        projectileRb.velocity = Vector3.zero;

        projectile.gameObject.SetActive(true);
        projectileRb.AddForce(shootPoint.forward * shoot.GetShootForce());
        projectile.DestroyPooledObjectWithTime(3f);
    }
}
