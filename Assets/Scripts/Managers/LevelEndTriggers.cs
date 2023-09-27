using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LevelEndTriggers : MonoBehaviour
{
    // Check if player has triggered the game object
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            LevelManager levelManager = GetComponentInParent<LevelManager>();

            if (levelManager != null )
            {
                levelManager.LevelEnd();
            }
        }
        Destroy(gameObject);
    }
    // Call LevelEnd on parent Game Object
    // Hint: You need access to the LevelManager component
}
