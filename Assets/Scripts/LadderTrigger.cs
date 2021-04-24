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
        climber.TryClimbLadder(Top.transform, Bottom.transform);
    }

}
