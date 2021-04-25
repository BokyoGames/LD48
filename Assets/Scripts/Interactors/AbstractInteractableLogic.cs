using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Abstract class that defines the logic for each interactable object
public abstract class AbstractInteractableLogic : MonoBehaviour
{

    // Set of interactors that are currently interacting with this object
    protected HashSet<Interactor> interactors = new HashSet<Interactor>();

    // Called when a new interactor is starting to work

    virtual public void OnUse(Interactor interactor) {
    }

    virtual public void OnStart(Interactor interactor) {
        interactors.Add(interactor);
        interactor.StartInteraction();
    }
    
    // Called when a certain interactor is stopping to work
    virtual public void OnStop(Interactor interactor) {
        interactors.Remove(interactor);
        interactor.StopInteraction();
    }

    // Called when everyone needs to stop working
    virtual public void StopAllWork() {
        foreach(var i in interactors) {
            i.StopInteraction();
        }
        interactors.Clear();
    }

    virtual public void StartDemolish() {
        StopAllWork();

        // Replace the demolished building iwth a buildinteractable instead
        GameObject instance = Instantiate(DataHandler.Handler.BuildablePrefab, this.gameObject.transform.position, this.gameObject.transform.rotation) as GameObject;
        instance.transform.parent = this.transform.parent;
        instance.GetComponent<Interactable>().Depth = gameObject.GetComponent<Interactable>().Depth;
        gameObject.SetActive(false);
    }

    // Called every time there is a new tick of work (update resource, etc)
    public abstract void OnTick();
}
