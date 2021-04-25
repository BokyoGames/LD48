using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Component to handle moving towards a target
public class MovementAI : MonoBehaviour
{

    public int Speed = 0;

    AbstractSelectable mover;
    AbstractSelectable target;
    LayerHandler layerHandler;

    void Awake() {
        // Make sure we are disabled
        this.enabled = false;
    }

    void Start() {
        mover = GetComponent<AbstractSelectable>();
        layerHandler = GameObject.FindGameObjectWithTag("LayerHandler").GetComponent<LayerHandler>();
    }

    public void AssignTarget(AbstractSelectable target) {
        this.target = target;
    }

    public void ClearTarget() {
        this.target = null;
    }

    void Update() {
        if(target == null) {
            Debug.LogWarning(gameObject.name + ": We are trying to move without a target");
            return;
        }
        // If we are interacting, it means we reached the target so we don't need
        // to move anymore.
        // TODO
        //if(interactor.IsInteracting || interactor.InteractionTarget == null) {
        //    this.enabled = false;
        //    return;
        //}

        Transform targetLocation = target.transform;
        // We need to go down one layer
        if(mover.Depth < target.Depth) {
            targetLocation = layerHandler.GetLadderOfLayer(mover.Depth + 1);
        }
        // We need to go up one layer
        else if(mover.Depth > target.Depth) {
            targetLocation = layerHandler.GetLadderOfLayer(mover.Depth);
        } 

        var movable = mover.GetComponent<Movable>();
        // Go to the target
        if(mover.transform.position.x > targetLocation.position.x) {
            // Need to go left
            if(movable.IsFacingRight)
                movable.OnFlip();
            this.transform.Translate(Vector3.left * Time.deltaTime * Speed);
        } else {
            // Need to go right
            if(!movable.IsFacingRight)
                movable.OnFlip();
            this.transform.Translate(Vector3.right * Time.deltaTime * Speed);
        }
    }
}
