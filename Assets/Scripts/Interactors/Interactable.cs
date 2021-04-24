using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Component on every object that can interact with Interactors
public class Interactable : AbstractSelectable
{

    DataHandler dataHandler;
    // The piece of logic that triggers an interaction
    public AbstractInteractableLogic InteractionResponder;

    float accumulator = 0;

    void Start() {
        InteractionResponder = GetComponent<AbstractInteractableLogic>();
        dataHandler = GameObject.FindGameObjectWithTag("DataHandler").GetComponent<DataHandler>();
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
        accumulator +=  (Time.deltaTime * 1000);
        while(accumulator > dataHandler.TickDurationInMilliseconds) {
            InteractionResponder.OnTick();
            accumulator -= dataHandler.TickDurationInMilliseconds;
        }
    }
}
