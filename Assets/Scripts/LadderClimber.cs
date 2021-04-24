using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderClimber : MonoBehaviour
{

    Interactor interactor;
    MovementAI movementAI;

    void Start() {
        interactor = GetComponent<Interactor>();
        movementAI = GetComponent<MovementAI>();
    }

    public void TryClimbLadder(Transform topLadder, Transform bottomLadder) {
        if(interactor.InteractionTarget == null) {
            // Nothing to be done
            return;
        }
        // Go Up
        if(interactor.InteractionTarget.Depth > interactor.Depth) {
            interactor.Depth += 1;
            interactor.transform.position = bottomLadder.position;
        }
        // Go Down
        else if(interactor.InteractionTarget.Depth < interactor.Depth) {
            interactor.Depth -= 1;
            interactor.transform.position = topLadder.position;
        }
    }
}
