using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineInteractor : AbstractInteractableLogic
{
    public int initial_quantity = 50;
    public int mine_time = 5;
    public ResourceType type = ResourceType.stone;
    private int quantity = 50;
    private ResourceHandler resources;
    void Start()
    {
        resources = GameObject.Find("ResourceContainer").GetComponent<ResourceHandler>();    
    }
    public override void OnTick() {
        if(interactors.Count > 0) {
            Debug.Log("Ticked!");
            Debug.Log("We have mined some " + type.ToString() + " interactors.");
            resources.setResourceType(type, 1*interactors.Count);
        }
    }
}
