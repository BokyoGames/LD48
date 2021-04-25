using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderTrigger : MonoBehaviour
{

    public Collider2D Top;
    public Collider2D Bottom;

    void OnTriggerStay2D(Collider2D col) {
        // We need to figure out if we want to go up or down (or nowhere)
        LadderClimber climber = col.GetComponentInParent<LadderClimber>();
        if(climber == null) {
            // Probably someone that shouldn't be climbing ladders
            Debug.LogWarning(col.gameObject.name + ": We can't climb ladders.");
            return;
        }
        climber.TryClimbLadder(Top.transform, Bottom.transform);
    }

}
