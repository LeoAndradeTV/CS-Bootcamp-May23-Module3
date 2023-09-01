using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISelectable
{
    void OnHoverEnter();
    void OnHoverExit();
    void OnSelect();
}
