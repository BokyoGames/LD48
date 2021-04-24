using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Component of a (playable) character that can interact with things
public class Interactor : AbstractSelectable
{
    private bool isInteracting = false;

    // The thing we want to interact with
    public Interactable InteractionTarget;
    // If we are already interacting with it or not
    public bool IsInteracting {
        get => isInteracting;
    }

    public void StartInteraction() {
        isInteracting = true;
        // Do other stuff here if we need to start interaction animations, etc
    }

    public void StopInteraction() {
        isInteracting = false;
    }

    public override void TriggerSelection() {
        base.TriggerSelection();
    }

    public override void TriggerUnselection() {
        base.TriggerUnselection();
    }

    void OnMouseDown() {
        // We have been clicked!
        var selector = GameObject.FindGameObjectWithTag("Player").GetComponent<SelectionStateHandler>(); 
        selector.OnClicked(this);
    }

    // Called by the selector when the panel "use" button is clicked
    public void OnUse(Interactable target) {
        // TODO handle interrupting animations if necessary
        if(InteractionTarget != target) {
            InteractionTarget = target;
            if(isInteracting) {
                StopInteraction();
            }
        }
        GetComponent<MovementAI>().enabled = true;
    }

    public void OnStop() {
        InteractionTarget = null;
        if(isInteracting)
            StopInteraction();
    }
}
