using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public static PlayerInput Instance { get; private set; }

    private float sprintMultiplier = 3f;

    [Header("Ground Check")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float groundCheckDistance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public Vector2 GetMovementInput()
    {
        return new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }

    public Vector2 GetPlayerRotation()
    {
        return new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
    }

    public float GetMoveMultiplier()
    {
        return Input.GetKey(KeyCode.LeftShift) ? sprintMultiplier : 1f;
    }

    public bool IsGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, groundCheckDistance, groundMask);
    }

    public bool JumpWasPressed()
    {
        return Input.GetButtonDown("Jump");
    }

    public bool BulletWasShot()
    {
        return Input.GetButtonDown("Fire1");
    }

    public bool RocketWasShot()
    {
        return Input.GetButtonDown("Fire2");
    }

    public bool HasInteracted()
    {
        return Input.GetKeyDown(KeyCode.E);
    }
}
