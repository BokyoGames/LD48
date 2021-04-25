using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : UseSelectable
{

    public AbstractEnemyLogic EnemyLogic;

    void Start() {
        EnemyLogic = GetComponent<AbstractEnemyLogic>();
    }

    public override void ConnectOnUse(Interactor interactor) {
        //EnemyLogic.OnStart(interactor);
    }

    public override void ConnectInteractor(Interactor interactor) {
        interactor.StartCombat(this);
        EnemyLogic.OnStart(interactor);
    }

    public override void DisconnectInteractor(Interactor interactor) {
        interactor.StopCombat();
        EnemyLogic.OnStop(interactor);
    }

    // Enemy AI Loop here
    public override void OnTick() {
        EnemyLogic.OnTick();
    }
}
