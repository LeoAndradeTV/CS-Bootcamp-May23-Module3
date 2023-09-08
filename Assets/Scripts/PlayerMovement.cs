using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController characterController;

    [SerializeField] private float speed = 5f;

    public Vector3 playerVelocity;
    private float gravity = -20f;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        characterController.Move((transform.forward * PlayerInput.Instance.GetMovementInput().y + transform.right * PlayerInput.Instance.GetMovementInput().x).normalized * Time.deltaTime * speed * PlayerInput.Instance.GetMoveMultiplier());

        if (PlayerInput.Instance.IsGrounded() && playerVelocity.y < 0)
        {
            playerVelocity.y = -2f;
        }

        playerVelocity.y += gravity * Time.deltaTime;

        characterController.Move(playerVelocity * Time.deltaTime);
    }
}
