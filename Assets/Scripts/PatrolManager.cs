using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolManager : MonoBehaviour
{
    public Transform PointA;
    public Transform PointB;

    public Transform GetOtherPoint(Transform point) {
        if(point == PointA) 
            return PointB;
        if(point == PointB)
            return PointA;
        return null;
    }
}
