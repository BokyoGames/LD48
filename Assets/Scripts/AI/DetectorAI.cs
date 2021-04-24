using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorAI : MonoBehaviour
{

    Enemy enemy;

    void Start() {
        enemy = gameObject.transform.parent.GetComponentInParent<Enemy>();
    }

    public void TargetDetected(Interactor interactor) {
        enemy.EnemyLogic.OnAggro(interactor);
    }

    void OnTriggerStay2D(Collider2D col) {
        // Enemy is already busy fighting, we don't need a new target
        if(enemy.EnemyLogic.HasFightingTarget) {
            return;
        }
        TargetDetected(col.GetComponentInParent<Interactor>());
    }
}
