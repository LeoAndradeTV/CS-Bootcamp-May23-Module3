using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    // Once the player comes close enough to the door, change colors for 1 second, then open the door.
    // Once the player leaves the door area, close the door

    [SerializeField] private Material playerCloseToDoor;
    [SerializeField] private Animator animator;

    private MeshRenderer meshRenderer;
    private Material startingMaterial;

    private float timer;
    private float maxTimer = 1;
    private bool isDoorLocked = true;
    private bool hasKey;

    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        //startingMaterial = meshRenderer.material;

        
    }

    private void OnEnable()
    {
        Actions.OnKeyPickedUp += KeyWasPickedUp;
    }

    private void OnDisable()
    {
        Actions.OnKeyPickedUp -= KeyWasPickedUp;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            timer = 0;
            //meshRenderer.material = playerCloseToDoor;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            timer += Time.deltaTime;

            if (timer >= maxTimer && !isDoorLocked)
            {
                //Open the door
                animator.SetBool("Door", true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            timer = 0;
            animator.SetBool("Door", false);
            //meshRenderer.material = startingMaterial;
        }
    }

    public void LockDoor()
    {
        isDoorLocked = true;
        animator.SetBool("Door", false);
    }

    public void UnlockDoor()
    {

        if (hasKey)
        {
            isDoorLocked = false;
            animator.SetBool("Door", true);
            Debug.Log("Door Unlocked!");

        }
    }

    private void KeyWasPickedUp()
    {
        hasKey = true;
    }
}
