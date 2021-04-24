using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Big class/component that keeps track of what unit is being selected, etc
public class SelectionStateHandler : MonoBehaviour
{
    // Unit that does the interaction
    public Interactor CurrentInteractorSelection;
    // Object that is interactable
    public Interactable CurrentInteractableSelection;

    public void OnClicked(Interactor interactor) {
        if(CurrentInteractorSelection != null) {
            CurrentInteractorSelection.TriggerUnselection();
            if(CurrentInteractorSelection == interactor) { 
                // We clicked on the same interactor twice, remove it and leave
                CurrentInteractorSelection = null;
                if(CurrentInteractableSelection != null) {
                    // We also clean up interactable interaction because we can't
                    // interact without an interactor
                    CurrentInteractableSelection.TriggerUnselection();
                    CurrentInteractableSelection = null;
                }
                return;
            }
        }
        // Start new selection
        interactor.TriggerSelection();
        CurrentInteractorSelection = interactor;
    }

    public void OnClicked(Interactable interactable) {
        if(CurrentInteractorSelection == null) {
            // We can't select an interactable if the interactor is not active
            return;
        }
        if(CurrentInteractableSelection != null) {
            CurrentInteractableSelection.TriggerUnselection();
            if(CurrentInteractableSelection == interactable) {
                // We clicked on the same interactable twice, remove it and leave
                CurrentInteractableSelection = null;
                return;
            }
        }
        interactable.TriggerSelection();
        CurrentInteractableSelection = interactable;
    }

    //public void SelectObject(GameObject newSelected) {
    //    var interactor = newSelected.GetComponent<Interactor>();
    //    // It's an interactor object!
    //    if(interactor != null) {
    //        handleInteractorSelection(interactor);
    //        return;
    //    } 

    //    var interactable = newSelected.GetComponent<Interactable>();
    //    // It's something we want to interact with!
    //    if (interactable != null) {
    //        handleInteractable(interactable);
    //        return;
    //    }
    //    // TODO: we might need a special case for enemies, maybe
    //}
}
