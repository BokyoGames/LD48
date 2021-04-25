using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NullEnemy : AbstractEnemyLogic
{
    public override void OnTick() {
        // Example state machine here
        if(HasFightingTarget && !IsFighting) {
            // Walk is handled in update out of ticks
            return;
        }

        if(IsFighting) {
            if(damageDealer.TickAndCheckIfWeShouldAttack())
                FightingTarget.DamageReceiver.OnDamage(this.gameObject, damageDealer.AttackParameter);
            return;
        }
    }

    void Update() {
        // Movement logic here
        if(HasFightingTarget && !IsFighting) {
            // Walk until target is in range
            return;
        }
    }

    public override void OnStart() {
        // Nothing to be done here
    }
}
