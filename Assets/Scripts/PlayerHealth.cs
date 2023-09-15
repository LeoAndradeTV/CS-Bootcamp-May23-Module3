using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private int maxHealth = 200;
    private int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    private void OnEnable()
    {
        Actions.OnPlayerAttacked += TakeDamage;
    }

    private void OnDisable()
    {
        Actions.OnPlayerAttacked -= TakeDamage;
    }
    private void TakeDamage()
    {
        currentHealth--;
        Debug.Log($"Player Health: {currentHealth}");
        if (currentHealth <= 0)
        {
            Actions.OnPlayerDied?.Invoke();
        }
    }
}
