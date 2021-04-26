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
            BuildPicker.SetActive(false);
            return;
        }

        if(consistencyHandler.CurrentInteractorSelection.InteractionTarget != null) {
            StopButton.interactable = true;
        } else {
            StopButton.interactable = false;
        }

        // Special buildpicker check
        var buildingMaybe = consistencyHandler.CurrentInteractableSelection.GetComponent<BuildInteractable>();
        if(buildingMaybe == null || (BuildPicker.activeInHierarchy && BuildPicker.GetComponent<PickerStatus>().build_reference != buildingMaybe)) {
            BuildPicker.SetActive(false);
        }

        if(consistencyHandler.CurrentInteractableSelection != null) {
            // We can't interact with this but we can still destroy it
            if(consistencyHandler.CurrentInteractableSelection.GetComponent<NullInteractable>() != null) {
                UseButton.interactable = false;
                DestroyButton.interactable = true;
                DestroyButton.gameObject.SetActive(true);
            } else {
                UseButton.interactable = true;
                CheckUseButtonAndChangeIcon();
                if (consistencyHandler.CurrentInteractableSelection.IsDestructible) {
                    DestroyButton.interactable = true;
                    DestroyButton.gameObject.SetActive(true);
                } else {
                    DestroyButton.interactable = false;
                    DestroyButton.gameObject.SetActive(false);
                }
            }
        } else {
            UseButton.interactable = false;
            DestroyButton.interactable = false;
            DestroyButton.gameObject.SetActive(false);
            BuildPicker.SetActive(false);
        }

        ButtonGroup.SetActive(true);
    }

    // Event called when the "use" button is clicked on the panel
    public void OnUse() {
        SFXHandler.GetInstance().PlayFX("ui_click");
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
        SFXHandler.GetInstance().PlayFX("ui_click");
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
        SFXHandler.GetInstance().PlayFX("ui_click");
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
        SFXHandler.GetInstance().PlayFX("ui_click");
        if(consistencyHandler.CurrentInteractorSelection == null) {
            Debug.LogWarning("This shouldn't happen, stop was clicked but no interactor was selected");
            return;
        }
        consistencyHandler.CurrentInteractorSelection.OnStop();
        BuildPicker.SetActive(false);
        consistencyHandler.SetDirty();
    }

}
