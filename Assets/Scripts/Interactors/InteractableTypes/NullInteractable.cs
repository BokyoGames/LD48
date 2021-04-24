using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Placeholder/fake interactable
public class NullInteractable : AbstractInteractableLogic
{
    public override void OnTick() {
        if(interactors.Count > 0) {
            Debug.Log("Ticked!");
            Debug.Log("We have " + interactors.Count + " interactors.");
        }
    }

    public override void OnStart(Interactor interactor) {
        base.OnStart(interactor);
    }

    public override void OnStop(Interactor interactor) {
        base.OnStop(interactor);
    }

    public override void StopAllWork() {
        base.StopAllWork();
    }
}
