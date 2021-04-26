using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickerStatus : MonoBehaviour
{
    public BuildInteractable build_reference;
    
    public void Build(GameObject obj) {
        build_reference.Build(obj);
    }

}
