using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateHead : MonoBehaviour
{
    [SerializeField] private Transform head;
    [SerializeField] private float turnSpeed;

    private float camXRotation;
    [SerializeField] private bool invertRotation;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        camXRotation += PlayerInput.Instance.GetPlayerRotation().y * turnSpeed * Time.deltaTime * (invertRotation ? -1 : 1);
        camXRotation = Mathf.Clamp(camXRotation, -85f, 85f);

        head.localRotation = Quaternion.Euler(camXRotation, 0, 0);
    }
}
