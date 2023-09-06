using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlayer : MonoBehaviour
{
    private PlayerInput input;

    [SerializeField] private float turnSpeed;

    // Start is called before the first frame update
    void Start()
    {
        input = GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * input.GetPlayerRotation().x * Time.deltaTime * turnSpeed);
    }
}
