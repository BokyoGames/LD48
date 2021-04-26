using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Big class/component that keeps track of what unit is being selected, etc
public class SelectionStateHandler : MonoBehaviour
{
    public Camera PreviewTargetCamera;
    public Camera PreviewInteractorCamera;
    public GameObject PreviewTargetCameraGroup;
    public GameObject PreviewInteractorCameraGroup;

    private ConsistencyStateHandler consistencyHandler;

    void Start() {
        consistencyHandler = GetComponent<ConsistencyStateHandler>();
    }

    public void OnClicked(Interactor interactor) {
        if(consistencyHandler.CurrentInteractorSelection != null) {
            consistencyHandler.CurrentInteractorSelection.TriggerUnselection();
            if(consistencyHandler.CurrentInteractorSelection == interactor) { 
                // We clicked on the same interactor twice, remove it and leave
                consistencyHandler.CurrentInteractorSelection = null;
                if(consistencyHandler.CurrentInteractableSelection != null) {
                    // We also clean up interactable interaction because we can't
                    // interact without an interactor
                    consistencyHandler.CurrentInteractableSelection.TriggerUnselection();
                    consistencyHandler.CurrentInteractableSelection = null;
                }
                consistencyHandler.SetDirty();
                return;
            }
        }
        // Start new selection
        interactor.TriggerSelection();
        consistencyHandler.CurrentInteractorSelection = interactor;
        consistencyHandler.SetDirty();
    }

    public void OnClicked(UseSelectable interactable) {
        if(consistencyHandler.CurrentInteractorSelection == null) {
            // We can't select an interactable if the interactor is not active
            consistencyHandler.SetDirty();
            return;
        }
        if(consistencyHandler.CurrentInteractableSelection != null) {
            consistencyHandler.CurrentInteractableSelection.TriggerUnselection();
            if(consistencyHandler.CurrentInteractableSelection == interactable) {
                // We clicked on the same interactable twice, remove it and leave
                consistencyHandler.CurrentInteractableSelection = null;
                consistencyHandler.SetDirty();
                return;
            }
        }
        interactable.TriggerSelection();
        consistencyHandler.CurrentInteractableSelection = interactable;
        consistencyHandler.SetDirty();
    }


    // In case the target/interactor has changed, we double check that the 
    // preview camera is being rendered correctly (or we hide it)
    public void PreviewCameraTargetCheck() {
        if(consistencyHandler.CurrentInteractorSelection != null) {
            // Our selected interactor is not targeting anything, hide the camera preview
            if(consistencyHandler.CurrentInteractorSelection.InteractionTarget == null) {
                PreviewTargetCameraGroup.SetActive(false);
                return;
            }
            // Make sure the camera is pointing to our interaction target
            Vector3 newPosition = consistencyHandler.CurrentInteractorSelection.InteractionTarget.transform.position;
            newPosition.z = PreviewTargetCamera.transform.position.z;
            PreviewTargetCamera.transform.position = newPosition;
            // Show the camera preview
            PreviewTargetCameraGroup.SetActive(true);
        } else {
            // No interactor selected, hide the camera preview.
            PreviewTargetCameraGroup.SetActive(false);
        }
    }

    public void PreviewCameraInteractorCheck() {
        // If no interactor is selected, hide camera
        if(consistencyHandler.CurrentInteractorSelection == null) {
            PreviewInteractorCameraGroup.SetActive(false);
        }

        // Make sure the camera is pointing to our interaction target
        Vector3 newPosition = consistencyHandler.CurrentInteractorSelection.transform.position;
        newPosition.z = PreviewInteractorCamera.transform.position.z;
        PreviewInteractorCamera.transform.position = newPosition;
        // Show the camera preview
        PreviewInteractorCameraGroup.SetActive(true);
    }

}
