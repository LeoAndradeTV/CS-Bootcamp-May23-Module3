using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PressurePad : MonoBehaviour
{
    [SerializeField] private float checkRadius;
    [SerializeField] private LayerMask pickUpLayer;

    public UnityEvent OnCubePlaced;
    public UnityEvent OnCubeRemoved;

    private void OnCollisionEnter(Collision collision)
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, checkRadius, pickUpLayer);

        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("PickCube"))
            {
                OnCubePlaced?.Invoke();
                break;
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("PickCube"))
        {
            OnCubeRemoved?.Invoke();
        }
    }
}
