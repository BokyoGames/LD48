using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickerStatus : MonoBehaviour
{
    public BuildInteractable build_reference;
    
    public void Build(GameObject obj)
    {
        Debug.Log("Asked to build an item");
        build_reference.Build(obj);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
