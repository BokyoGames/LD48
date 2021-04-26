using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Placeholder/fake interactable
public class SpawnInteractor : AbstractInteractableLogic
{
    public int max_spawn_time = 60;
    public int spawn_time = 60;

    [Range(0, 10f)]
    public float randomXSpawnVariance = 5f;

    public ProgressTracker Tracker;

    public GameObject dwarf;

    private ResourceHandler resources;

    private string[] spawnAudioClips = {"dwarf_spawn1", "dwarf_spawn2", "dwarf_spawn3", "dwarf_spawn4"};

    void Start()
    {
        resources = GameObject.Find("ResourceContainer").GetComponent<ResourceHandler>();
    }

    public override void OnTick() {
        if(interactors.Count > 0) {
            spawn_time -= interactors.Count;
            
            if(spawn_time <= 0) {
                spawn_time = max_spawn_time;
                if(resources.getResourceType(ResourceType.happiness) < resources.getResourceMaxType(ResourceType.happiness)) {
                    if(SFXHandler.GetInstance().CanPlaySpawnSFX) {
                        SFXHandler.GetInstance().PlayRandomFX(spawnAudioClips);
                    }
                    resources.addResourceType(ResourceType.happiness, 1);
                    float randomX = Random.Range(0, randomXSpawnVariance) - randomXSpawnVariance / 2f;
                    GameObject instance = Instantiate(dwarf, this.gameObject.transform.position, this.gameObject.transform.rotation) as GameObject;
                    var dwarfParent = GameObject.FindGameObjectWithTag("DwarfHolder");
                    instance.transform.parent = dwarfParent.transform;
                    Vector3 newPosition = new Vector3(instance.transform.position.x + randomX, instance.transform.position.y, instance.transform.position.z);
                    instance.transform.position = newPosition;
                    instance.GetComponent<Interactor>().Depth = gameObject.GetComponent<Interactable>().Depth;
                }
            }
        }
        if(Tracker != null) {
            Tracker.MaxValue = max_spawn_time;
            Tracker.CurrentValue = max_spawn_time - spawn_time;
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
