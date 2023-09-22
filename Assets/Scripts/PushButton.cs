using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PushButton : MonoBehaviour, ISelectable
{
    [SerializeField] private Material onHoverMaterial;

    public UnityEvent OnPush;

    private MeshRenderer meshRenderer;
    private Material onExitHoverMaterial;


    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        //onExitHoverMaterial = meshRenderer.material;
    }

    public void OnHoverEnter()
    {
        //meshRenderer.material = onHoverMaterial;
        Debug.Log("Hovering");
    }

    public void OnHoverExit()
    {
        //meshRenderer.material = onExitHoverMaterial;
        Debug.Log("Not hovering");
    }

    public void OnSelect()
    {
        OnPush.Invoke();
    }
}
