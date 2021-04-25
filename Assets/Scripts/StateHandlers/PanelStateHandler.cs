using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelStateHandler : MonoBehaviour
{

    public Button UseButton;
    public Button StopButton;
    public GameObject ButtonGroup;
    public GameObject BuildPicker;
    public GameObject TutorialHandler;

    private ConsistencyStateHandler consistencyHandler;

    void Start() {
        consistencyHandler = GetComponent<ConsistencyStateHandler>();
    }

    public void PanelButtonCheck() {
        if(consistencyHandler.CurrentInteractorSelection == null) {
            // Hide all panels cause we don't need them
            ButtonGroup.SetActive(false);
            return;
        }

        if(consistencyHandler.CurrentInteractorSelection.InteractionTarget != null) {
            StopButton.interactable = true;
        } else {
            StopButton.interactable = false;
        }

        if(consistencyHandler.CurrentInteractableSelection != null) {
            UseButton.interactable = true;
        } else {
            UseButton.interactable = false;
        }

        ButtonGroup.SetActive(true);
    }

    // Event called when the "use" button is clicked on the panel
    public void OnUse() {
        if(consistencyHandler.CurrentInteractorSelection == null) {
            Debug.LogWarning("This shouldn't happen, use was clicked but no interactor was selected");
            return;
        }
        if(consistencyHandler.CurrentInteractableSelection == null) {
            Debug.LogWarning("This shouldn't happen, use was clicked but no interactable was selected");
            return;
        }
        consistencyHandler.CurrentInteractorSelection.OnUse(consistencyHandler.CurrentInteractableSelection);
        consistencyHandler.SetDirty();
    }

    public void OnSelect(GameObject obj) {
        Debug.Log("Select element");
        if(BuildPicker.GetComponent<PickerStatus>().build_reference)
            BuildPicker.GetComponent<PickerStatus>().Build(obj);
    }

    public void OnStop() {
        if(consistencyHandler.CurrentInteractorSelection == null) {
            Debug.LogWarning("This shouldn't happen, stop was clicked but no interactor was selected");
            return;
        }
        consistencyHandler.CurrentInteractorSelection.OnStop();
        consistencyHandler.SetDirty();
    }

}
