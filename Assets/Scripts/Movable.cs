using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Component for things that can move
public class Movable : MonoBehaviour
{

    public SpriteRenderer spriteRenderer;
    Animator anim;

    MovementAI ai;

    public bool IsFacingRight {
        get => !spriteRenderer.flipX;
    }

    void Start() {
        ai = GetComponent<MovementAI>();
        anim = spriteRenderer.GetComponent<Animator>();
    }

    
    // Event called when we flip
    public virtual void OnFlip() {
        spriteRenderer.flipX = !spriteRenderer.flipX;
    }

    public void StartMovement(AbstractSelectable target) {
        ai.AssignTarget(target);
        ai.enabled = true;
        anim.Play("Walk");
    }

    public void StopMovement() {
        ai.ClearTarget();
        ai.enabled = false;
        // TODO: Need to handle more complex states like attack/etc
        anim.Play("Idle");
    }

}
