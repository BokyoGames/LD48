using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PulsingLayerComponent : MonoBehaviour
{
    [Range(0,1)]
    public float MinAlphaRange;
    [Range(0,1)]
    public float MaxAlphaRange;
    [Range(0,2000)]
    public float PulseSpeed;

    public RawImage Image;

    float startTime;

    void Start() {
        startTime = Time.time;
    }

    void Update() {
        if(Image.gameObject.activeInHierarchy) {
            var timeDiff = (Time.time - startTime) * 1000;
            float value = Mathf.Sin(((timeDiff % PulseSpeed) / PulseSpeed) * Mathf.PI * 2);
            value = value * (MaxAlphaRange - MinAlphaRange);
            Color temp = Image.color;
            temp.a = value;
            Image.color = temp;
        }
    }

    public void StartPulse() {
        Image.gameObject.SetActive(true);
    }

    public void StopPulse() {
        Image.gameObject.SetActive(false);
    }
}
