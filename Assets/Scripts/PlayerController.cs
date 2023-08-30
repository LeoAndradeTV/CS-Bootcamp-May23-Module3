using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform head;

    [SerializeField] private float speed = 5f;
    [SerializeField] private float turnSpeed = 3f;
    [SerializeField] private bool invertRotation = true;
    [SerializeField] private float jumpVelocity;

    private CharacterController characterController;

    [Header("Ground Check")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float groundCheckDistance;

    [Header("Shoot")]
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject rocketPrefab;
    [SerializeField] private float shootForce;
    [SerializeField] private Transform shootPoint;

    private float horizontalInput;
    private float verticalInput;
    private float mouseX;
    private float mouseY;
    private float moveMultiplier;
    private float sprintMultiplier = 3f;
    private float camXRotation;
    private float gravity = -20f;

    private bool isGrounded;

    private Vector3 playerVelocity;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();

        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        MovePlayer();
        RotatePlayer();
        GroundCheck();
        JumpCheck();
        Shoot();
        ShootRocket();
    }

    void GetInput()
    {
        horizontalInput = Input.GetAxis("Horizontal"); // return a float between -1 and 1
        verticalInput = Input.GetAxis("Vertical"); // return a float between -1 and 1
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");

        moveMultiplier = Input.GetKey(KeyCode.LeftShift) ? sprintMultiplier : 1;
    }

    private void MovePlayer()
    {
        characterController.Move((transform.forward * verticalInput + transform.right * horizontalInput).normalized * Time.deltaTime * speed * moveMultiplier);

        if (isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = -2f;
        }

        playerVelocity.y += gravity * Time.deltaTime;

        characterController.Move(playerVelocity * Time.deltaTime);
    }

    private void RotatePlayer()
    {
        // Rotate the Player
        transform.Rotate(Vector3.up * mouseX * Time.deltaTime * turnSpeed);

        // Rotate the head
        camXRotation += mouseY * turnSpeed * Time.deltaTime * (invertRotation ? -1 : 1);
        camXRotation = Mathf.Clamp(camXRotation, -85f, 85f);

        head.localRotation = Quaternion.Euler(camXRotation, 0, 0);
    }

    private void GroundCheck()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckDistance, groundMask);
    }

    private void JumpCheck()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            playerVelocity.y = jumpVelocity;
        }
    }

    private void Shoot()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody>().AddForce(shootPoint.forward * shootForce);
            Destroy(bullet, 3f);
        }
    }

    private void ShootRocket()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            GameObject rocket = Instantiate(rocketPrefab, shootPoint.position, Quaternion.identity);
            rocket.GetComponent<Rigidbody>().AddForce(shootPoint.forward * shootForce);
            Destroy(rocket, 3f);
        }
    }
}
