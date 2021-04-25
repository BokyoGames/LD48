using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepositLogic : MonoBehaviour
{
    public List<ResourceType> resources_type;
    public List<int> quantity;
    private ResourceHandler resources;
    // Start is called before the first frame update
    void Start()
    {
        resources = GameObject.Find("ResourceContainer").GetComponent<ResourceHandler>();

        for(int i = 0; i<resources_type.Count; i++)
        {
            resources.addResourceMaxType(resources_type[i], quantity[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
