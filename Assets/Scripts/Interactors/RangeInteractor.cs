using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Component that detects if an Interactor has entered in range and triggers
// an interaction
public class RangeInteractor : MonoBehaviour
{
    public Interactable InteractableParent;

    private bool isRightInteractor(Interactor interactor) {
        if(interactor == null) {
            // Nothing to be done, ignore
            return false;
        }

        if(interactor.InteractionTarget.gameObject != gameObject.transform.parent.gameObject) {
            // Nothing to be done, it's not the target that we are looking for
            return false;
        }

        return true;
    }

    void OnTriggerEnter2D(Collider2D col) {
        var interactor = col.gameObject.GetComponentInParent<Interactor>();
        if(isRightInteractor(interactor) && !interactor.IsInteracting) {
            // Start interaction sequence
            InteractableParent.ConnectInteractor(interactor);
            interactor.StartInteraction();
        }
    }
}
