﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataHandler : MonoBehaviour
{
    public static DataHandler Handler {
        get => GameObject.FindGameObjectsWithTag("DataHandler")[0].GetComponent<DataHandler>();
    }

    public int TickDurationInMilliseconds = 0;
    public int DepthReached = 0;
    public GameObject BuildablePrefab;

    public float BattleSFXInterval;
    private float lastBattleSFX = 0f;

    public bool CanPlayBattleSFX {
        get {
            if((Time.time - lastBattleSFX) * 1000 > BattleSFXInterval) {
                lastBattleSFX = Time.time;
                return true;
            }
            return false;
        }
    }
}
