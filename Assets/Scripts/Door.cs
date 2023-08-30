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

    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        startingMaterial = meshRenderer.material;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            timer = 0;
            meshRenderer.material = playerCloseToDoor;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            timer += Time.deltaTime;

            if (timer >= maxTimer)
            {
                //Open the door
                animator.SetBool("b_isDoorOpen", true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            timer = 0;
            animator.SetBool("b_isDoorOpen", false);
            meshRenderer.material = startingMaterial;
        }
    }
}
