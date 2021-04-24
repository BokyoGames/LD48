using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildInfo : MonoBehaviour
{
    public GameObject structure;
    private PanelStateHandler player_state_handler;
    private ResourceHandler resources;

    private List<ResourceType> resource_types;
    private List<int> resource_quantities;

    public void OnSelect() {
        player_state_handler.OnSelect(structure);
    }

    // Start is called before the first frame update
    void Start()
    {
        resources = GameObject.Find("ResourceContainer").GetComponent<ResourceHandler>();    
        player_state_handler = GameObject.FindGameObjectWithTag("Player").GetComponent<PanelStateHandler>();
        
        resource_types = structure.GetComponent<GenericStructure>().requested_resource_type;
        resource_quantities = structure.GetComponent<GenericStructure>().requested_resource_quantity;
    }

    // Update is called once per frame
    void Update()
    {
        var buildable = true;
        for(int i = 0; i < resource_types.Count; i++)
        {
            if(resources.getResourceType(resource_types[i]) < resource_quantities[i])
                buildable = false;
        }

        GetComponent<Button>().interactable = buildable;
    }
}
