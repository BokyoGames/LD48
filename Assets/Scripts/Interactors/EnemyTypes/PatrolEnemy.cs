using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolEnemy : AbstractEnemyLogic
{

    Movable movable;
    [HideInInspector]
    public Transform PatrolTarget;
    public PatrolManager PatrolManager;

    public override void OnStart() {
        movable = GetComponent<Movable>();
        damageDealer = GetComponent<DamageDealer>();
        if(PatrolTarget == null) {
            PatrolTarget = PatrolManager.PointA;
        }
        movable.anim.Play("Walk");
    }

    public override void OnTick() {
        if(HasFightingTarget && !IsFighting) {
            return;
        }

        if(IsFighting) {
            if(damageDealer.TickAndCheckIfWeShouldAttack()) {
                if(FightingTarget == null) {
                    TargetChange();
                    return;
                }
                if(SFXHandler.GetInstance().CanPlayAttackSFX)
                    SFXHandler.GetInstance().PlayFX("dwarf_attack");
                FightingTarget.DamageReceiver.OnDamage(this.gameObject, damageDealer.AttackParameter);
            }
            return;
        }
    }

    public override void OnStop(Interactor interactor) {
        base.OnStop(interactor);
        if(!HasFightingTarget) {
            IsFighting = false;
            movable.anim.Play("Walk");
        }
    }

    void Update() {
        // Movement logic here
        if(HasFightingTarget && !IsFighting && !movable.IsMoving) {
            movable.StartMovement(FightingTarget);
            return;
        }
        if(IsFighting && movable.IsMoving) {
            movable.StopMovement();
            return;
        }

        // Not allowed to patrol if we are already moving or fighting >:(
        if(movable.IsMoving || IsFighting)
            return;

        // We are patrolling
        if(this.transform.position.x > PatrolTarget.transform.position.x) {
            if(movable.IsFacingRight)
                movable.OnFlip();
            this.transform.Translate(Vector3.left * Time.deltaTime * (movable.MovementSpeed * 0.5f));
        } else {
            if(!movable.IsFacingRight)
                movable.OnFlip();
            this.transform.Translate(Vector3.right * Time.deltaTime * (movable.MovementSpeed * 0.5f));
        }
    }
}
