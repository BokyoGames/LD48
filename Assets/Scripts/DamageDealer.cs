using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    // How much damage we deal
    public int AttackParameter = 0;
    // After how many ticks we attack
    public int AttackInterval = 0;

    int tickAccumulator = 0;

    public bool TickAndCheckIfWeShouldAttack() {
        tickAccumulator += 1;
        if(tickAccumulator >= AttackInterval) {
            tickAccumulator = 0;
            return true;
        }
        return false;
    }

    public void ResetTicks() {
        tickAccumulator = 0;
    }
}
