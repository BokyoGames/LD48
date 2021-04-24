using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Component on every object that can interact with Interactors
public class Interactable : AbstractSelectable
{
    // TODO
    // The piece of logic that triggers an interaction
    public Component InteractionResponder;

    private Interactor interactor;

    public void ConnectInteractor(Interactor interactor) {
        this.interactor = interactor;
        interactor.StartInteraction();
    }

    public void DisconnectInteractor() {
        this.interactor.StopInteraction();
        this.interactor = null;
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
}
