using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Component on every object that can interact with Interactors
public class Interactable : UseSelectable
{

    // The piece of logic that triggers an interaction
    public AbstractInteractableLogic InteractionResponder;

    public override void OnStart() {
        InteractionResponder = GetComponent<AbstractInteractableLogic>();
    }

    public override void ConnectOnUse(Interactor interactor) {
        InteractionResponder.OnUse(interactor);
    }

    public override void ConnectInteractor(Interactor interactor) {
        InteractionResponder.OnStart(interactor);
    }

    public override void DisconnectInteractor(Interactor interactor) {
        InteractionResponder.OnStop(interactor);
    }

    public override void TriggerSelection() {
        base.TriggerSelection();
    }

    public override void TriggerUnselection() {
        base.TriggerUnselection();
    }

    public override void OnTick() {
        InteractionResponder.OnTick();
    }

    public override void Demolish() {
        if(IsDestructible) {
            InteractionResponder.StartDemolish();
            SFXHandler.GetInstance().PlayFX("building_collapse");
        }
    }
}
