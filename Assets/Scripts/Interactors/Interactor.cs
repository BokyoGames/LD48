using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Component of a (playable) character that can interact with things
public class Interactor : MonoBehaviour
{
    private bool isInteracting = false;

    // The thing we want to interact with
    public GameObject InteractionTarget;
    // If we are already interacting with it or not
    public bool IsInteracting {
        get => isInteracting;
    }

    public void StartInteraction() {
        isInteracting = true;
        // Do other stuff here if we need to start interaction animations, etc
    }

    public void StopInteraction() {
        isInteracting = false;
    }
}
