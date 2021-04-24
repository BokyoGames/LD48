using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractSelectable : MonoBehaviour
{
    public virtual void TriggerSelection() {
        var selectable = GetComponentInChildren<UISelectableLogic>();
        selectable.ToggleSelectable(true);
    }

    public virtual void TriggerUnselection() {
        var selectable = GetComponentInChildren<UISelectableLogic>();
        selectable.ToggleSelectable(false);
    }
}
