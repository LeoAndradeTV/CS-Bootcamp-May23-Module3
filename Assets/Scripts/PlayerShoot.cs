using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private Rigidbody bulletPrefab;
    [SerializeField] private Rigidbody rocketPrefab;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private float shootForce = 1000f;

    private PlayerInput input;

    // Start is called before the first frame update
    void Start()
    {
        input = GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        if (input.BulletWasShot())
        {
            Rigidbody bullet = Instantiate(bulletPrefab, shootPoint.position, Quaternion.identity);
            bullet.AddForce(shootPoint.forward * shootForce);
            Destroy(bullet.gameObject, 3f);
        }

        if (input.RocketWasShot())
        {
            Rigidbody rocket = Instantiate(rocketPrefab, shootPoint.position, Quaternion.identity);
            rocket.AddForce(shootPoint.forward * shootForce);
            Destroy(rocket.gameObject, 3f);
        }
    }
}
