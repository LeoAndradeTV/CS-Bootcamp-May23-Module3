using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PlayerInput input;
    private CharacterController characterController;

    [SerializeField] private float speed = 5f;

    public Vector3 playerVelocity;
    private float gravity = -20f;

    // Start is called before the first frame update
    void Start()
    {
        input = GetComponent<PlayerInput>();
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        characterController.Move((transform.forward * input.GetMovementInput().y + transform.right * input.GetMovementInput().x).normalized * Time.deltaTime * speed * input.GetMoveMultiplier());

        if (input.IsGrounded() && playerVelocity.y < 0)
        {
            playerVelocity.y = -2f;
        }

        playerVelocity.y += gravity * Time.deltaTime;

        characterController.Move(playerVelocity * Time.deltaTime);
    }
}
