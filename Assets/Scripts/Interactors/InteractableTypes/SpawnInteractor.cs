using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Placeholder/fake interactable
public class SpawnInteractor : AbstractInteractableLogic
{
    public int max_spawn_time = 60;
    public int spawn_time = 60;

    public GameObject dwarf;
    public override void OnTick() {
        if(interactors.Count > 0) {
            spawn_time -= interactors.Count;
            
            if(spawn_time <= 0)
            {
                spawn_time = max_spawn_time;
                Debug.Log("Spawn a little dwarf");
                GameObject instance = Instantiate(dwarf, this.gameObject.transform.position, this.gameObject.transform.rotation) as GameObject;
                instance.GetComponent<Interactor>().Depth = gameObject.GetComponent<Interactable>().Depth;
            }
        }
    }

    public override void OnStart(Interactor interactor) {
        base.OnStart(interactor);
    }

    public override void OnStop(Interactor interactor) {
        base.OnStop(interactor);
    }

    public override void StopAllWork() {
        base.StopAllWork();
    }
}
