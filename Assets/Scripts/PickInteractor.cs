using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickInteractor : Interactor
{
    private IPickable currentPickable;
    [SerializeField] private Transform attachPoint;

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        if (isHitting)
        {
            IPickable pickable = hit.collider.GetComponent<IPickable>();

            if (pickable != null && PlayerInput.Instance.HasInteracted())
            {
                currentPickable = pickable;
                pickable.OnPicked(attachPoint);
                return;
            }
        }

        if (currentPickable != null && PlayerInput.Instance.HasInteracted())
        {
            currentPickable.OnDropped();
            currentPickable = null;
        } 
    }
}
