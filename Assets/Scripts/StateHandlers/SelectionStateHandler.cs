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

    // TODO: maybe refactor this
    public Camera PreviewTargetCamera;
    public GameObject PreviewTargetCameraGroup;

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
                previewCameraTargetCheck();
                return;
            }
        }
        // Start new selection
        interactor.TriggerSelection();
        CurrentInteractorSelection = interactor;
        previewCameraTargetCheck();
    }

    public void OnClicked(Interactable interactable) {
        if(CurrentInteractorSelection == null) {
            // We can't select an interactable if the interactor is not active
            previewCameraTargetCheck();
            return;
        }
        if(CurrentInteractableSelection != null) {
            CurrentInteractableSelection.TriggerUnselection();
            if(CurrentInteractableSelection == interactable) {
                // We clicked on the same interactable twice, remove it and leave
                CurrentInteractableSelection = null;
                previewCameraTargetCheck();
                return;
            }
        }
        interactable.TriggerSelection();
        CurrentInteractableSelection = interactable;
        previewCameraTargetCheck();
    }

    // In case the target/interactor has changed, we double check that the 
    // preview camera is being rendered correctly (or we hide it)
    private void previewCameraTargetCheck() {
        if(CurrentInteractorSelection != null) {
            // Our selected interactor is not targeting anything, hide the camera preview
            if(CurrentInteractorSelection.InteractionTarget == null) {
                PreviewTargetCameraGroup.SetActive(false);
                return;
            }
            // Make sure the camera is pointing to our interaction target
            Vector3 newPosition = CurrentInteractorSelection.InteractionTarget.transform.position;
            newPosition.z = PreviewTargetCamera.transform.position.z;
            PreviewTargetCamera.transform.position = newPosition;
            // Show the camera preview
            PreviewTargetCameraGroup.SetActive(true);
        } else {
            // No interactor selected, hide the camera preview.
            PreviewTargetCameraGroup.SetActive(false);
        }
    }
}
