using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelStateHandler : MonoBehaviour
{

    public Button UseButton;
    public Button StopButton;
    public Button DestroyButton;
    public GameObject ButtonGroup;
    public GameObject BuildPicker;
    public GameObject TutorialHandler;

    private ConsistencyStateHandler consistencyHandler;

    void Start() {
        consistencyHandler = GetComponent<ConsistencyStateHandler>();
    }

    void CheckUseButtonAndChangeIcon() {
        if(consistencyHandler.CurrentInteractableSelection == null)
            return; // ignore
        var multiHolder = UseButton.GetComponent<MultipleButtonImageHolder>();
        if(multiHolder == null)
            return;

        switch(consistencyHandler.CurrentInteractableSelection.SelectableType) {
            case SelectableType.Ore:
                UseButton.GetComponent<Image>().sprite = multiHolder.ButtonImageList[0];
            break;
            case SelectableType.Enemy:
                UseButton.GetComponent<Image>().sprite = multiHolder.ButtonImageList[1];
            break;
            case SelectableType.Building:
                UseButton.GetComponent<Image>().sprite = multiHolder.ButtonImageList[2];
            break;
        }
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
            CheckUseButtonAndChangeIcon();
            if(consistencyHandler.CurrentInteractableSelection.IsDestructible) {
                DestroyButton.interactable = true;
            } else {
                DestroyButton.interactable = false;
            }
        } else {
            UseButton.interactable = false;
            DestroyButton.interactable = false;
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
        if(BuildPicker.GetComponent<PickerStatus>().build_reference)
            BuildPicker.GetComponent<PickerStatus>().Build(obj);
        if(consistencyHandler.CurrentInteractorSelection == null) {
            Debug.LogWarning("This shouldn't happen, use was clicked but no interactor was selected");
            return;
        }
        if(consistencyHandler.CurrentInteractableSelection == null) {
            Debug.LogWarning("This shouldn't happen, use was clicked but no interactable was selected");
            return;
        }
        consistencyHandler.CurrentInteractorSelection.OnUse(consistencyHandler.CurrentInteractableSelection);
    }

    public void OnDestroyButton() {
        if(consistencyHandler.CurrentInteractorSelection == null) {
            Debug.LogWarning("This shouldn't happen, use was clicked but no interactor was selected");
            return;
        }
        if(consistencyHandler.CurrentInteractableSelection == null) {
            Debug.LogWarning("This shouldn't happen, use was clicked but no interactable was selected");
            return;
        }
        // This is like normal OnUse but instead we try to destroy
        consistencyHandler.CurrentInteractorSelection.OnUse(consistencyHandler.CurrentInteractableSelection, true);
        consistencyHandler.SetDirty();
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
