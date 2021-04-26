using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsistencyStateHandler : MonoBehaviour
{
    // Unit that does the interaction
    public Interactor CurrentInteractorSelection;
    // Object that is interactable
    public UseSelectable CurrentInteractableSelection;

    private bool isDirty = false;
    public void SetDirty() {
        isDirty = true;
    }

    SelectionStateHandler selectionHandler;
    PanelStateHandler panelHandler;
    NamePanelStateHandler namePanelHandler;

    // Start is called before the first frame update
    void Start()
    {
        selectionHandler = GetComponent<SelectionStateHandler>();
        panelHandler = GetComponent<PanelStateHandler>();
        namePanelHandler = GetComponent<NamePanelStateHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isDirty)  {
            selectionHandler.PreviewCameraInteractorCheck();
            selectionHandler.PreviewCameraTargetCheck();
            panelHandler.PanelButtonCheck();
            namePanelHandler.NamePanelCheck();
            isDirty = false;
        }
    }

    // When an interactor dies, we check if we have some broken state or not in the panel
    public void OnInteractorDeath(Interactor interactor) {
        if(CurrentInteractorSelection == interactor) {
            CurrentInteractorSelection = null;
            CurrentInteractableSelection = null;
            SetDirty();
        }
    }
}
