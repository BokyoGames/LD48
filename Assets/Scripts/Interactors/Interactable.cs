using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Component on every object that can interact with Interactors
public class Interactable : AbstractSelectable
{
    // TODO
    // The piece of logic that triggers an interaction
    public AbstractInteractableLogic InteractionResponder;

    void Start() {
        InteractionResponder = GetComponent<AbstractInteractableLogic>();
    }

    public void ConnectInteractor(Interactor interactor) {
        InteractionResponder.OnStart(interactor);
    }

    public void DisconnectInteractor(Interactor interactor) {
        InteractionResponder.OnStop(interactor);
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

    void Update() {
        // TODO implement tick logic / timer
        InteractionResponder.OnTick();
    }
}
