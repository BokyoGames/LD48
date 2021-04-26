using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NamePanelStateHandler : MonoBehaviour
{

    public NamePanelHandler panelHandler;

    private ConsistencyStateHandler consistencyHandler;

    void Start() {
        consistencyHandler = GetComponent<ConsistencyStateHandler>();
    }

    public void NamePanelCheck() {
        if(consistencyHandler.CurrentInteractorSelection == null) {
            panelHandler.gameObject.SetActive(false);
        } else {
            panelHandler.NameField.text = consistencyHandler.CurrentInteractorSelection.DwarfName;
            panelHandler.JobField.text = consistencyHandler.CurrentInteractorSelection.Job;
            panelHandler.gameObject.SetActive(true);
        }
    }
}
