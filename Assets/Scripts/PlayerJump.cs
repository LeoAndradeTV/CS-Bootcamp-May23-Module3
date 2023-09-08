using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{

    private PlayerMovement playerMovement;

    [SerializeField] private float jumpVelocity;

    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerInput.Instance.JumpWasPressed() && PlayerInput.Instance.IsGrounded())
        {
            playerMovement.playerVelocity.y = jumpVelocity;
        }
    }
}
