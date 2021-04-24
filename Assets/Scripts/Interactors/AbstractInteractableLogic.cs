using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Abstract class that defines the logic for each interactable object
public abstract class AbstractInteractableLogic : MonoBehaviour
{

    // Set of interactors that are currently interacting with this object
    protected HashSet<Interactor> interactors = new HashSet<Interactor>();

    // Called when a new interactor is starting to work
    public void OnStart(Interactor interactor) {
        interactors.Add(interactor);
        interactor.StartInteraction();
    }
    
    // Called when a certain interactor is stopping to work
    public void OnStop(Interactor interactor) {
        interactors.Remove(interactor);
        interactor.StopInteraction();
    }

    // Called when everyone needs to stop working
    public void StopAllWork() {
        foreach(var i in interactors) {
            i.StopInteraction();
        }
        interactors.Clear();
    }

    // Called every time there is a new tick of work (update resource, etc)
    public abstract void OnTick();
}
