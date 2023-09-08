using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    //[SerializeField] private Rigidbody bulletPrefab;
    //[SerializeField] private Rigidbody rocketPrefab;
    [SerializeField] private ObjectPool bulletPool;
    [SerializeField] private ObjectPool rocketPool;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private float shootForce = 1000f;

    // Update is called once per frame
    void Update()
    {
        if (PlayerInput.Instance.BulletWasShot())
        {
            ShootProjectile(bulletPool);
        }

        if (PlayerInput.Instance.RocketWasShot())
        {
            ShootProjectile(rocketPool);
        }
    }

    private void ShootProjectile(ObjectPool pool)
    {
        PooledObject projectile = pool.GetPooledObject();
        Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();

        // Reset the position of the reused bullet
        projectile.transform.position = shootPoint.position;

        projectileRb.velocity = Vector3.zero;

        projectile.gameObject.SetActive(true);
        projectileRb.AddForce(shootPoint.forward * shootForce);
        projectile.DestroyPooledObjectWithTime(3f);
    }
}
