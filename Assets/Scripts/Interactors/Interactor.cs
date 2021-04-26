using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Component of a (playable) character that can interact with things
public class Interactor : AbstractSelectable
{
    private bool isInteracting = false;
    public bool wantToDestroy = false;
    public string DwarfName = "";

    // If we are fighting an enemy, combat target is not null
    DamageReceiver combatTarget;
    private bool inCombat {
        get => combatTarget != null;
    }

    public string Job = "Miner";

    private string[] useAudioClips = {"okay4", "okay5", "okay6", "okay7", "okay8"};
    private string[] battleAudioClips = {"battle4", "battle5", "battle6", "battle7"};
    private string[] deathAudioClips = {"death4", "death5", "death6", "death7", "death8", "death9"};

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
        if(wantToDestroy) {
            // Force cast because we can, but we shouldn't
            ((UseSelectable)InteractionTarget).Demolish();
        } else {
            movable.anim.Play("Interacting");
        }
    }

    // Special function called when an interactor attaches to an enemy
    public void StartCombat(Enemy enemy) {
        combatTarget = enemy.GetComponent<DamageReceiver>();
        if(SFXHandler.GetInstance().CanPlayBattleSFX)
            SFXHandler.GetInstance().PlayRandomFX(battleAudioClips);
        movable.anim.Play("Interacting");
    }

    public void StopCombat() {
        combatTarget = null;
        // Not in combat anymore, reset the tick counter
        damageDealer.ResetTicks();
        movable.anim.Play("Idle");
    }

    public void StopInteraction() {
        isInteracting = false;
        wantToDestroy = false;
        movable.anim.Play("Idle");
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


    // Called by the selector when the panel "use" button is clicked
    public void OnUse(UseSelectable target, bool wantToDestroy = false) {
        if(InteractionTarget == target)
            return;
        target.ConnectOnUse(this);

        SFXHandler.GetInstance().PlayRandomFX(useAudioClips);
        // TODO handle interrupting animations if necessary
        if(InteractionTarget != target) {
            OnStop();
            InteractionTarget = target;
        }
        this.wantToDestroy = wantToDestroy;
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
                if(SFXHandler.GetInstance().CanPlayAttackSFX)
                    SFXHandler.GetInstance().PlayFX("dwarf_attack");
                combatTarget.OnDamage(this.gameObject, damageDealer.AttackParameter);
            }
        } 
    }

    public override void OnDeath() {
        OnStop();

        // Tell the selectable panel that we died
        GameObject.FindGameObjectWithTag("Player").GetComponent<ConsistencyStateHandler>().OnInteractorDeath(this);

        ResourceHandler resources = GameObject.Find("ResourceContainer").GetComponent<ResourceHandler>();
        resources.addResourceType(ResourceType.happiness, -1);

        SFXHandler.GetInstance().PlayRandomFX(deathAudioClips);
        base.OnDeath();
    }

    void Update() {
        if(DwarfName == "") {
            DwarfName = GetComponent<Namable>().GetFullName();
        }
    }

    // In case the interactable thing dies before we get there
    void LateUpdate() {
        if(InteractionTarget == null && !isInteracting && movable.IsMoving && combatTarget == null) {
            movable.StopMovement();
        }
    }
}
