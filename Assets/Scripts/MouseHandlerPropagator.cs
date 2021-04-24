using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseHandlerPropagator : MonoBehaviour
{
    public UseSelectable selectable;

    void OnMouseDown() {
        selectable.DoMouseDown();
    }
}
