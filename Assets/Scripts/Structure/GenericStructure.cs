using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericStructure : MonoBehaviour
{

    public string structure_name;
    public List<int> requested_resource_quantity;
    public List<ResourceType> requested_resource_type;
    public int min_level = 0;
    public int expertise_required = 0;

    public int build_time = 20;
    public StructureType type;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
