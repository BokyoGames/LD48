using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Component of a (playable) character that can interact with things
public class Interactor : AbstractSelectable
{
    private bool isInteracting = false;

    // If we are fighting an enemy, combat target is not null
    DamageReceiver combatTarget;
    private bool inCombat {
        get => combatTarget != null;
    }

    private string[] useAudioClips = {"okay1", "okay2", "okay3"};
    private string[] battleAudioClips = {"battle1", "battle2", "battle3"};
    private string[] deathAudioClips = {"death1", "death2", "death3"};

    public DamageReceiver DamageReceiver;
    DamageDealer damageDealer;

    Movable movable;

    public override void OnStart() {
        DamageReceiver = GetComponent<DamageReceiver>();
        damageDealer = GetComponent<DamageDealer>();
        movable = GetComponent<Movable>();
    }

    // If we are already interacting with it or not
    public bool IsInteracting {
        get => isInteracting;
    }

    public void StartInteraction() {
        isInteracting = true;
        movable.StopMovement();
        // Do other stuff here if we need to start interaction animations, etc
    }

    // Special function called when an interactor attaches to an enemy
    public void StartCombat(Enemy enemy) {
        combatTarget = enemy.GetComponent<DamageReceiver>();
        playBattleAudio();
    }

    public void StopCombat() {
        combatTarget = null;
        // Not in combat anymore, reset the tick counter
        damageDealer.ResetTicks();
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

    void playBattleAudio() {
        var randomIndex = Random.Range(0, battleAudioClips.Length);
        SFXHandler.GetInstance().PlayFX(battleAudioClips[randomIndex]);
    }

    void playDeathAudio() {
        var randomIndex = Random.Range(0, deathAudioClips.Length);
        SFXHandler.GetInstance().PlayFX(deathAudioClips[randomIndex]);
    }

    // Called by the selector when the panel "use" button is clicked
    public void OnUse(UseSelectable target) {
        if(InteractionTarget == target)
            return;
        target.ConnectOnUse(this);

        playUseAudio();
        // TODO handle interrupting animations if necessary
        if(InteractionTarget != target) {
            OnStop();
            InteractionTarget = target;
        }
        //GetComponent<MovementAI>().enabled = true;
        movable.StartMovement(InteractionTarget);
    }

    public void OnStop() {
        if(isInteracting) {
            // Force cast because we can, but we shouldn't
            ((UseSelectable)InteractionTarget).DisconnectInteractor(this);
        }
        InteractionTarget = null;
    }

    public override void OnTick() {
        if(inCombat) {
            if(damageDealer.TickAndCheckIfWeShouldAttack()) {
                combatTarget.OnDamage(damageDealer.AttackParameter);
            }
        } 
    }

    public override void OnDeath() {
        OnStop();

        // Tell the selectable panel that we died
        GameObject.FindGameObjectWithTag("Player").GetComponent<ConsistencyStateHandler>().OnInteractorDeath(this);

        base.OnDeath();
        playDeathAudio();
    }
}
