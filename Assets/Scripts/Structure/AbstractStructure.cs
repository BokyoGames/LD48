using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceQuantity
{
    ResourceType type;
    int quantity;
}

public class AbstractStructure : MonoBehaviour
{

    public string structure_name;
    public ResourceQuantity[] requested_resource;
    public int min_level = 0;
    public int expertise_required = 0;    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
