using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Builder : MonoBehaviour
{
    [SerializeField] private GameObject objectToBuild;
    [SerializeField] private Transform objectLocation;

    public void Build()
    {
        Instantiate(objectToBuild, objectLocation.position, objectLocation.rotation);
        Destroy(gameObject);
    }
}
