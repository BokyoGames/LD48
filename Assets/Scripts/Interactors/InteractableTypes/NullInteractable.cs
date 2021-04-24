using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Placeholder/fake interactable
public class NullInteractable : AbstractInteractableLogic
{
    public override void OnTick() {
        Debug.Log("Ticked!");
        Debug.Log("We have " + interactors.Count + " interactors.");
    }
}
