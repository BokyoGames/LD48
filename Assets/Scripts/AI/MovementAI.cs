using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Component to handle moving towards a target
public class MovementAI : MonoBehaviour
{

    public int Speed = 0;

    Interactor interactor;
    LayerHandler layerHandler;

    void Start() {
        interactor = GetComponent<Interactor>();
        layerHandler = GameObject.FindGameObjectWithTag("LayerHandler").GetComponent<LayerHandler>();
    }

    void Update() {
        // If we are interacting, it means we reached the target so we don't need
        // to move anymore.
        if(interactor.IsInteracting || interactor.InteractionTarget == null) {
            this.enabled = false;
            return;
        }

        AbstractSelectable interactable = interactor.InteractionTarget;
        Transform target = interactable.transform;
        // We need to go down one layer
        if(interactor.Depth < interactable.Depth) {
            target = layerHandler.GetLadderOfLayer(interactor.Depth + 1);
        }
        // We need to go up one layer
        else if(interactor.Depth > interactable.Depth) {
            target = layerHandler.GetLadderOfLayer(interactor.Depth);
        } 

        // Go to the target
        if(interactor.transform.position.x > target.position.x) {
            // Need to go left
            this.transform.Translate(Vector3.left * Time.deltaTime * Speed);
        } else {
            // Need to go right
            this.transform.Translate(Vector3.right * Time.deltaTime * Speed);
        }
    }
}
