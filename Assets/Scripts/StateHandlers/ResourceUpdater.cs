using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceUpdater : MonoBehaviour
{
    ResourceHandler resources;
    string resource_type;
    private Text text_field;
    // Start is called before the first frame update
    void Start()
    {
        resources = GameObject.Find("ResourceContainer").GetComponent<ResourceHandler>();
        resource_type = name.ToLower();
        text_field = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text_field.text = resources.getResourceType(resource_type).ToString() + " / " + resources.getResourceMaxType(resource_type).ToString();
    }
}
