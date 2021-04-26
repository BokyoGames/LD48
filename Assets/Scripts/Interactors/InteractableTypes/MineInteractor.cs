using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineInteractor : AbstractInteractableLogic
{
    public int initial_quantity = 50;
    public int mine_time = 5;
    public ResourceType type = ResourceType.stone;

    public Discoverable ObstructionLayer;

    private int quantity = 50;
    private ResourceHandler resources;
    private int tick_count = 0;

    void Start() {
        quantity = initial_quantity;
        resources = GameObject.Find("ResourceContainer").GetComponent<ResourceHandler>();
    }

    public override void OnStop(Interactor interactor){
        base.OnStop(interactor);
        if(type == ResourceType.mithril && interactors.Count == 0) {
            GameObject.FindGameObjectWithTag("MusicManager").GetComponent<MusicManager>().StopMithril();
            GameObject.FindGameObjectWithTag("PulsingLayer").GetComponent<PulsingLayerComponent>().StopPulse();
        }
    }

    public override void OnStart(Interactor interactor) {
        if(type == ResourceType.mithril && interactors.Count == 0) {
            GameObject.FindGameObjectWithTag("MusicManager").GetComponent<MusicManager>().PlayMithril();
            GameObject.FindGameObjectWithTag("PulsingLayer").GetComponent<PulsingLayerComponent>().StartPulse();
        }
        base.OnStart(interactor);
    }


    public override void OnTick() {
        if(interactors.Count > 0) {
            if(initial_quantity != -1 && quantity <=0) {

                if(ObstructionLayer) {
                    ObstructionLayer.Discover();
                }

                Destroy(gameObject);
                StopAllWork();
                return;
            }

            var buildPower = 0;
            foreach(var i in interactors) {
                var builder = i.GetComponent<Builder>();
                if(builder != null) {
                    buildPower += builder.Power;
                } else {
                    buildPower++;
                }
            }
            
            tick_count += buildPower;

            if(tick_count > mine_time) {
                int unused = resources.addResourceType(type, tick_count/mine_time);
                quantity -= tick_count/mine_time + unused;
                tick_count = tick_count % mine_time;
            }
        }
    }

    public override void StopAllWork() {
        base.StopAllWork();
        // TODO: temporary audio cue, gotta fix with the real one
        SFXHandler.GetInstance().PlayFX("sfx_build");
    }

}
