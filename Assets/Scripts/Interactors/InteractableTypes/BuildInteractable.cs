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
    private ResourceHandler resources;

    // Start is called before the first frame update
    void Start()
    {
        build_picker = GameObject.FindGameObjectWithTag("Player").GetComponent<PanelStateHandler>().BuildPicker;
        resources = GameObject.Find("ResourceContainer").GetComponent<ResourceHandler>();
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

    public override void OnStop(Interactor interactor)
    {
        base.OnStop(interactor);
        if(structure == null)
        {
            build_picker.SetActive(false);
        }
    }

    public void Build(GameObject obj)
    {
        structure = obj;
        build_time = structure.GetComponent<GenericStructure>().build_time;
        build_picker.SetActive(false);

        var structure_info = structure.GetComponent<GenericStructure>();
        
        for(int i = 0; i < structure_info.requested_resource_type.Count; i++)
        {
            resources.addResourceType(structure_info.requested_resource_type[i], -structure_info.requested_resource_quantity[i]);
        }
    }

    public void Complete()
    {
        Debug.Log("Complete the building");
        StopAllWork();
        GameObject instance = Instantiate(structure, this.gameObject.transform.position, this.gameObject.transform.rotation) as GameObject;

        instance.GetComponent<Interactable>().Depth = gameObject.GetComponent<Interactable>().Depth;
        gameObject.SetActive(false);
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
