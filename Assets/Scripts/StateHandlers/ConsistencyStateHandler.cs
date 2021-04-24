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

    // Start is called before the first frame update
    void Start()
    {
        selectionHandler = GetComponent<SelectionStateHandler>();
        panelHandler = GetComponent<PanelStateHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isDirty)  {
            selectionHandler.PreviewCameraTargetCheck();
            panelHandler.PanelButtonCheck();
            isDirty = false;
        }
    }
}
