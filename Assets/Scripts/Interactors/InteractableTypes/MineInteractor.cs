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

    void Start()
    {
        quantity = initial_quantity;
        resources = GameObject.Find("ResourceContainer").GetComponent<ResourceHandler>();
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

            Debug.Log("Ticked!");
            tick_count += interactors.Count;

            if(tick_count > mine_time) {
                Debug.Log("We have mined some " + type.ToString() + " interactors.");
                int unused = resources.addResourceType(type, tick_count/mine_time);
                quantity -= tick_count/mine_time + unused;
                tick_count = tick_count % mine_time;
            }
        }
    }
}
