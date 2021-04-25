using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Component of a (playable) character that can interact with things
public class Interactor : AbstractSelectable
{
    private bool isInteracting = false;
    private string[] useAudioClips = {"okay1", "okay2", "okay3"};

    // The thing we want to interact with
    //public UseSelectable InteractionTarget;
    public DamageReceiver DamageReceiver;

    void Start() {
        DamageReceiver = GetComponent<DamageReceiver>();
    }

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

    public override void TriggerSelection() {
        base.TriggerSelection();
    }

    public override void TriggerUnselection() {
        base.TriggerUnselection();
    }

    void OnMouseDown() {
        // We have been clicked!
        var selector = GameObject.FindGameObjectWithTag("Player").GetComponent<SelectionStateHandler>(); 
        selector.OnClicked(this);
    }

    void playUseAudio() {
        var randomIndex = Random.Range(0, useAudioClips.Length);
        SFXHandler.GetInstance().PlayFX(useAudioClips[randomIndex]);
    }

    // Called by the selector when the panel "use" button is clicked
    public void OnUse(UseSelectable target) {
        target.ConnectOnUse(this);

        playUseAudio();
        // TODO handle interrupting animations if necessary
        if(InteractionTarget != target) {
            OnStop();
            InteractionTarget = target;
        }
        GetComponent<MovementAI>().enabled = true;
    }

    public void OnStop() {
        if(isInteracting) {
            // Force cast because we can, but we shouldn't
            ((UseSelectable)InteractionTarget).DisconnectInteractor(this);
        }
        InteractionTarget = null;
    }
}
