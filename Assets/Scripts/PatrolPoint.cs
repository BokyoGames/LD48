using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolPoint : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col) {
        var patrol = col.GetComponentInParent<PatrolEnemy>();
        if(patrol == null) {
            Debug.Log("Some other enemy (not patrol) collided, ignore.");
            return;
        }
        // We reached the right patrol target
        if(patrol.PatrolTarget == this.transform) {
            var otherPoint = GetComponentInParent<PatrolManager>().GetOtherPoint(this.transform);
            if(otherPoint == null) {
                Debug.LogWarning("Incorrect patrol point was returned from patrol manager.");
            }
            patrol.PatrolTarget = otherPoint;
            patrol.GetComponentInChildren<Animator>().Play("Walk");
        }
    }
}
