using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StructureType
{
    house
}

public class BuildInteractable : AbstractInteractableLogic
{
    private GameObject build_picker;

    private StructureType type;

    // Start is called before the first frame update
    void Start()
    {
        build_picker = GameObject.FindGameObjectWithTag("Player").GetComponent<PanelStateHandler>().BuildPicker;
    }

    public override void OnUse(Interactor interactor)
    {
        base.OnUse(interactor);
        Debug.Log("Ask to use this builder");
        build_picker.SetActive(true);
        build_picker.GetComponent<PickerStatus>().build_reference = this;        
    }

    public void Build(StructureType type)
    {
        this.type = type;
        build_picker.SetActive(false);
    }

    public override void OnTick() {
        if(interactors.Count > 0) {
        }
    }
}
