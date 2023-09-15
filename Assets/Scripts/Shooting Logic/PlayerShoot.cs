using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    //[SerializeField] private Rigidbody bulletPrefab;
    //[SerializeField] private Rigidbody rocketPrefab;
    public MeshRenderer gunMeshRenderer;
    public Material bulletMaterial;
    public Material rocketMaterial;

    [SerializeField] private ObjectPool bulletPool;
    [SerializeField] private ObjectPool rocketPool;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private float shootForce = 1000f;

    private IShootStrategy strategy;

    // Update is called once per frame
    void Update()
    {
        if (strategy == null)
        {
            strategy = new BulletShootStrategy(this, bulletPool, bulletMaterial);
        }

        if (PlayerInput.Instance.Weapon1Pressed())
        {
            strategy = new BulletShootStrategy(this, bulletPool, bulletMaterial);
        }

        if (PlayerInput.Instance.Weapon2Pressed())
        {
            strategy = new RocketShootStrategy(this, rocketPool, rocketMaterial);
        }

        if (PlayerInput.Instance.ShootWasPressed() && strategy != null)
        {
            strategy.Shoot();
        }
    }


    public float GetShootForce()
    {
        return shootForce;
    }

    public ObjectPool GetBulletPool()
    {
        return bulletPool;
    }

    public ObjectPool GetRocketPool()
    {
        return rocketPool;
    }

    public Transform GetShootPoint()
    {
        return shootPoint;
    }
}
