using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StructureType
{
    undefined,
    house
}

public class BuildInteractable : AbstractInteractableLogic
{
    private GameObject build_picker;

    private GameObject structure;

    private int build_time;

    // Start is called before the first frame update
    void Start()
    {
        build_picker = GameObject.FindGameObjectWithTag("Player").GetComponent<PanelStateHandler>().BuildPicker;
    }

    public override void OnUse(Interactor interactor)
    {
        if(structure == null)
        {
            base.OnUse(interactor);
            Debug.Log("Ask to use this builder");
            build_picker.SetActive(true);
            build_picker.GetComponent<PickerStatus>().build_reference = this;        
        }
    }

    public void Build(GameObject obj)
    {
        this.structure = obj;
        build_time = this.structure.GetComponent<GenericStructure>().build_time;
        build_picker.SetActive(false);
    }

    public void Complete()
    {
        Debug.Log("Complete the building");
        StopAllWork();
        GameObject instance = Instantiate(structure, this.gameObject.transform.position, this.gameObject.transform.rotation) as GameObject;
        Destroy(this.gameObject);
    }

    public override void OnTick() {
        if(structure != null)
        {
            if(interactors.Count > 0 && build_time > 0) {
                build_time -= interactors.Count;
                if(build_time <= 0)
                {
                    Complete();
                }
            }
        }
    }
}
