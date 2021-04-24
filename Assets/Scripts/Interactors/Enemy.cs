using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : UseSelectable
{

    DataHandler dataHandler; 

    public AbstractEnemyLogic EnemyLogic;

    float accumulator = 0;

    void Start() {
        EnemyLogic = GetComponent<AbstractEnemyLogic>();
        dataHandler = GameObject.FindGameObjectWithTag("DataHandler").GetComponent<DataHandler>();
    }

    public override void ConnectOnUse(Interactor interactor) {
        //EnemyLogic.OnStart(interactor);
    }

    public override void ConnectInteractor(Interactor interactor) {
        //EnemyLogic.OnStart(interactor);
    }

    public override void DisconnectInteractor(Interactor interactor) {
        //EnemyLogic.OnStop(interactor);
    }

    void OnMouseDown() {
        var selector = GameObject.FindGameObjectWithTag("Player").GetComponent<SelectionStateHandler>(); 
        selector.OnClicked(this);
    }

    // Enemy AI loop here
    void Update() {
        accumulator +=  (Time.deltaTime * 1000);
        while(accumulator > dataHandler.TickDurationInMilliseconds) {
            //EnemyLogic.OnTick();
            //TODO
            accumulator -= dataHandler.TickDurationInMilliseconds;
        }
    }
}
