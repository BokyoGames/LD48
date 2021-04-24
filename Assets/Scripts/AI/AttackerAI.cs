using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerAI : MonoBehaviour
{
    Enemy enemy;

    void Start() {
        enemy = gameObject.transform.parent.GetComponentInParent<Enemy>();
    }

    void OnTriggerStay2D(Collider2D col) {
        // Not the right enemy or we are already fighting, ignore
        if(enemy.EnemyLogic.FightingTarget != col.GetComponentInParent<Interactor>() || enemy.EnemyLogic.IsFighting)
            return;
        enemy.EnemyLogic.OnStartFight();
    }
}
