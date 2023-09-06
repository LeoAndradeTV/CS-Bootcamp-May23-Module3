using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    private PlayerInput input;
    private PlayerMovement playerMovement;

    [SerializeField] private float jumpVelocity;

    // Start is called before the first frame update
    void Start()
    {
        input = GetComponent<PlayerInput>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (input.JumpWasPressed() && input.IsGrounded())
        {
            playerMovement.playerVelocity.y = jumpVelocity;
        }
    }
}
