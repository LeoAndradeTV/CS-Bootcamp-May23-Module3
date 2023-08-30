using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        IDestroyable destroyable = collision.gameObject.GetComponent<IDestroyable>();
        Debug.Log("You've hit something");
        if (destroyable != null)
        {
            Debug.Log("It has been destroyed");

            destroyable.OnCollided();
        }

        IEdible edible = collision.gameObject.GetComponent<IEdible>();

        if (edible != null)
        {
            Debug.Log("It has been eaten");

            edible.Eat();
        }
    }
}
