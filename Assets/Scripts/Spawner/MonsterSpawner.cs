using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    DataHandler dataHandler; 
    public GameObject monster;
    public int max_delay;

    public int Depth;

    public int max_number_of_monster;

    [Range(0, 10f)]
    public float randomXSpawnVariance = 5f;

    private int delay;
    private int spawned;
    private float accumulator;


    // Start is called before the first frame update
    void Start()
    {
        delay = max_delay;
        spawned = max_number_of_monster;
    }

    void OnTick()
    {
        delay--;
        if(delay <= 0 && (spawned > 0|| spawned != -1))
        {
            delay = max_delay;
            GameObject instance = Instantiate(monster, this.gameObject.transform.position, this.gameObject.transform.rotation) as GameObject;
            instance.transform.parent = this.transform.parent;
            float randomX = Random.Range(0, randomXSpawnVariance) - randomXSpawnVariance / 2f;
            Vector3 newPosition = new Vector3(instance.transform.position.x + randomX, instance.transform.position.y, instance.transform.position.z);
            instance.transform.position = newPosition;

            instance.GetComponent<Interactable>().Depth = Depth;
        }
    }

    // Update is called once per frame
    void Update() {
        // Lazy initialization cause sometimes it messes up
        if(dataHandler == null)  {
            dataHandler = DataHandler.Handler;
            return;
        }
        accumulator +=  (Time.deltaTime * 1000);
        while(accumulator > dataHandler.TickDurationInMilliseconds) {
            OnTick();
            accumulator -= dataHandler.TickDurationInMilliseconds;
        }
    }
}
