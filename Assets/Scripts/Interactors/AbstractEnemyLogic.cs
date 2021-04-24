using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class AbstractEnemyLogic : MonoBehaviour
{

    // Dwarves engaged in fighting the enemy
    protected HashSet<Interactor> interactors = new HashSet<Interactor>();

    // Dwarf being targeted by the enemy
    protected Interactor fightingTarget;

    // TODO: Add buildings later
    //protected Interactable buildingTarget;

    // Called every time there is a new tick for the enemy to attack/do stuff/etc
    public abstract void OnTick();

    virtual public void OnStart(Interactor interactor) {
        interactors.Add(interactor);
        interactor.StartInteraction();
    }

    // Called when a certain interactor is not fighting the enemy anymore
    virtual public void OnStop(Interactor interactor) {
        interactors.Remove(interactor);
        interactor.StopInteraction();
    }

    virtual public void OnDeath() {
        foreach(var i in interactors) {
            i.StopInteraction();
        }
        interactors.Clear();
    }

    // Select a new target
    virtual public void TargetChange() {
        if(interactors.Count > 0 && fightingTarget == null) {
            // Get a new random target
            fightingTarget = interactors.ToList()[Random.Range(0, interactors.Count)];
        }

        // TODO: finish logic here
    }
}
