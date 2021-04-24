﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Discoverable : MonoBehaviour
{
    public Rigidbody2D CaveCover;
    public void Discover() {
        // Disable the layer, we now have a new discovered object
        if(CaveCover.gameObject.activeInHierarchy) {
            CaveCover.gameObject.SetActive(false);
        }

        // TODO - Send events to other listeners that the layer has been discovered
    }
}