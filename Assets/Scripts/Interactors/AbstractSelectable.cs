using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractSelectable : MonoBehaviour
{

    DataHandler dataHandler; 
    // Time accumulator for ticks
    float accumulator = 0;

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

    // Generic OnTick function, called when a tick passes for the given selectable
    public virtual void OnTick() { }

    // Use this instead of Start()
    public virtual void OnStart() { }

    // Called when this element needs to disappear/die
    public virtual void OnDeath() {
        GameObject.Destroy(this.gameObject);
    }

    void Start() {
        dataHandler = DataHandler.Handler;
        OnStart();
    }

    void Update() {
        // Lazy initialization cause sometimes it messes up
        if(dataHandler == null)  {
            dataHandler = DataHandler.Handler;
            return;
        }
        accumulator +=  (Time.deltaTime * 1000);
        while(accumulator > dataHandler.TickDurationInMilliseconds) {
            OnTick();
            accumulator -= dataHandler.TickDurationInMilliseconds;
        }
    }

}
