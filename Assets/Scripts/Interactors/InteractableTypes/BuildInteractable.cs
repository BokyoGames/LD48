using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StructureType
{
    undefined,
    house,
    spawn,
    deposit,
    hospital,
}

public class BuildInteractable : AbstractInteractableLogic
{
    private GameObject build_picker;

    private GameObject structure;

    private int build_time;
    private ResourceHandler resources;

    public ProgressTracker Tracker;

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
        if(Tracker != null)
            Tracker.MaxValue = build_time;
        build_picker.SetActive(false);

        var structure_info = structure.GetComponent<GenericStructure>();
        
        for(int i = 0; i < structure_info.requested_resource_type.Count; i++)
        {
            resources.addResourceType(structure_info.requested_resource_type[i], -structure_info.requested_resource_quantity[i]);
        }
    }

    public void Complete()
    {
        StopAllWork();
        GameObject instance = Instantiate(structure, this.gameObject.transform.position, this.gameObject.transform.rotation) as GameObject;
        instance.transform.parent = this.transform.parent;

        instance.GetComponent<Interactable>().Depth = gameObject.GetComponent<Interactable>().Depth;
        gameObject.SetActive(false);
    }

    public override void StopAllWork() {
        base.StopAllWork();
        SFXHandler.GetInstance().PlayFX("sfx_build");
    }

    public override void OnTick() {
        if(structure != null) {
            if(Tracker != null && !Tracker.gameObject.activeInHierarchy) {
                Tracker.gameObject.SetActive(true);
            }
            if(interactors.Count > 0 && build_time > 0) {
                var buildPower = 0;
                foreach(var i in interactors) {
                    var builder = i.GetComponent<Builder>();
                    if(builder != null) {
                        buildPower += builder.Power;
                    } else {
                        buildPower++;
                    }

                }
                build_time -= buildPower;
                if(Tracker != null) {
                    Tracker.CurrentValue = (Tracker.MaxValue - build_time);
                }
                if(build_time <= 0)
                {
                    Complete();
                }
            }
        } 
    }
}
