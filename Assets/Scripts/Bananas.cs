using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bananas : MonoBehaviour, IEdible
{
    public void Eat()
    {
        Debug.Log("Good job! You chose the correct one.");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
