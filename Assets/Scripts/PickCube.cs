using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickCube : MonoBehaviour, IPickable
{
    private Rigidbody cubeRb;

    // Start is called before the first frame update
    void Start()
    {
        cubeRb = GetComponent<Rigidbody>();
    }

    public void OnDropped()
    {
        cubeRb.isKinematic = false;
        cubeRb.useGravity = true;
        transform.parent = null;
    }

    public void OnPicked(Transform attachPoint)
    {
        transform.position = attachPoint.position;
        transform.rotation = attachPoint.rotation;
        transform.parent = attachPoint.transform;
        cubeRb.isKinematic = true;
        cubeRb.useGravity = false;
    }
}
