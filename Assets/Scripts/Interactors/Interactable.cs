using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Component on every object that can interact with Interactors
public class Interactable : MonoBehaviour
{
    // TODO
    // The piece of logic that triggers an interaction
    public Component InteractionResponder;

    private Interactor interactor;

    public void ConnectInteractor(Interactor interactor) {
        this.interactor = interactor;
        interactor.StartInteraction();
        Debug.Log("Logged!");
    }

    public void DisconnectInteractor() {
        this.interactor.StopInteraction();
        this.interactor = null;
    }
}
