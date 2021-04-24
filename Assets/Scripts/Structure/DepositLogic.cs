using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepositLogic : MonoBehaviour
{
    private ResourceHandler resources;
    // Start is called before the first frame update
    void Start()
    {
        resources = GameObject.Find("ResourceContainer").GetComponent<ResourceHandler>();
        resources.addResourceMaxType(ResourceType.stone, 20);
        resources.addResourceMaxType(ResourceType.iron, 20);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
