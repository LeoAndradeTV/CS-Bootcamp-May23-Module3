using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleInteractor : Interactor
{
    private ISelectable currentSelectable;

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        if (isHitting)
        {
            ISelectable selectable = hit.collider.GetComponent<ISelectable>();

            if (selectable != null)
            {
                currentSelectable = selectable;
                selectable.OnHoverEnter();

                if (PlayerInput.Instance.HasInteracted())
                {
                    selectable.OnSelect();
                }
            }
        }

        if (!isHitting && currentSelectable != null)
        {
            currentSelectable.OnHoverExit();
            currentSelectable = null;
        }
    }
}
