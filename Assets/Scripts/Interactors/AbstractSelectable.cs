using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractSelectable : MonoBehaviour
{

    public AbstractSelectable InteractionTarget;

    // This value indicates at which depth the object is in the layer hierarchy.
    // This way the AI can decide if they need to use a ladder to go up/down
    // a layer to reach the same depth as the interactable they are trying to
    // reach or not.
    public int Depth = 0;

    public virtual void TriggerSelection() {
        var selectable = GetComponentInChildren<UISelectableLogic>();
        selectable.ToggleSelectable(true);
    }

    public virtual void TriggerUnselection() {
        var selectable = GetComponentInChildren<UISelectableLogic>();
        selectable.ToggleSelectable(false);
    }
}
