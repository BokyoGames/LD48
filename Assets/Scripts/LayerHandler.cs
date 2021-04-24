using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerHandler : MonoBehaviour
{
    // Ladders for each layer
    public List<Transform> Layers;

    public Transform GetLadderOfLayer(int index) {
        // We need -1 here, don't ask why.
        return Layers[index - 1];
    }
}
