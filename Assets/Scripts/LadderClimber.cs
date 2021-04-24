using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderClimber : MonoBehaviour
{

    Interactor interactor;
    MovementAI movementAI;
    LayerHandler layerHandler;

    void Start() {
        interactor = GetComponent<Interactor>();
        movementAI = GetComponent<MovementAI>();
        layerHandler = GameObject.FindGameObjectWithTag("LayerHandler").GetComponent<LayerHandler>();
    }

    public void TryClimbLadder(Transform topLadder, Transform bottomLadder) {
        if(interactor.InteractionTarget == null) {
            // Nothing to be done
            return;
        }

        var ladderDepth = layerHandler.Layers.FindIndex(l => l == topLadder.parent.transform) + 1;

        // We want to go down
        if(interactor.InteractionTarget.Depth > interactor.Depth) {
            // Wrong ladder, ignore
            if(ladderDepth == interactor.Depth) {
                return;
            }
            interactor.Depth += 1;
            interactor.transform.position = bottomLadder.position;
        }
        // Go Up
        else if(interactor.InteractionTarget.Depth < interactor.Depth) {
            if(ladderDepth - 1 == interactor.Depth) {
                return;
            }
            interactor.Depth -= 1;
            interactor.transform.position = topLadder.position;
        }
    }
}
