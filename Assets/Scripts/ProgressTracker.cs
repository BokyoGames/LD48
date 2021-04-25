using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressTracker : MonoBehaviour
{

    public int MaxValue;
    public int CurrentValue;

    public SpriteRenderer FrontBar;

    void Update() {
        Vector3 scale = FrontBar.transform.localScale;
        scale.x = (float) CurrentValue / (float) MaxValue;
        FrontBar.transform.localScale = scale;
    }
}
