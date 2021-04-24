using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NullEnemy : AbstractEnemyLogic
{
    public int AttackParameter = 0;
    public int Speed = 5;

    public override void OnTick() {
        // Example state machine here
        if(HasFightingTarget && !IsFighting) {
            // Walk is handled in update out of ticks
            return;
        }

        if(IsFighting) {
            FightingTarget.DamageReceiver.OnDamage(AttackParameter);
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
}
