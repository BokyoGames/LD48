﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UseSelectable : AbstractSelectable
{
    public abstract void ConnectInteractor(Interactor interactor);
    public abstract void DisconnectInteractor(Interactor interactor);

    public void DoMouseDown() {
        var selector = GameObject.FindGameObjectWithTag("Player").GetComponent<SelectionStateHandler>(); 
        selector.OnClicked(this);
    }
}
