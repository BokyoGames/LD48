using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolEnemy : AbstractEnemyLogic
{

    Movable movable;

    public override void OnStart() {
        movable = GetComponent<Movable>();
        damageDealer = GetComponent<DamageDealer>();
    }

    public override void OnTick() {
        // Example state machine here
        if(HasFightingTarget && !IsFighting) {
            // Walk is handled in update out of ticks
            return;
        }

        if(IsFighting) {
            if(damageDealer.TickAndCheckIfWeShouldAttack()) {
                if(FightingTarget == null) {
                    TargetChange();
                    return;
                }
                FightingTarget.DamageReceiver.OnDamage(damageDealer.AttackParameter);
            }
            return;
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
    }
}
