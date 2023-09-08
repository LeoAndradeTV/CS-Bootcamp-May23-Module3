using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    private Ray ray;
    protected RaycastHit hit;
    protected bool isHitting;

    [SerializeField] private LayerMask interactableLayer;

    // Update is called once per frame
    public virtual void Update()
    {
        ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width/2, Screen.height/2, 0));
        isHitting = Physics.Raycast(ray, out hit, 2f, interactableLayer);
    }
}
