using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDraggableCamera : MonoBehaviour
{

    public float DragSpeed = 2;

    public float LimitPerDepth;
    public float MaxYValue;
    [Range(0, 1f)]
    public float ClampValue;

    void LateUpdate() {
        if (Input.GetMouseButton(1)) {

            var newPosition = transform.position;


            newPosition.y -= Mathf.Clamp(Input.GetAxis("Mouse Y"), -ClampValue, ClampValue) * DragSpeed * Time.deltaTime;

            newPosition.y = Mathf.Clamp(newPosition.y, DataHandler.Handler.DepthReached * LimitPerDepth, MaxYValue);

            // translates to the opposite direction of mouse position.
            transform.position = newPosition;
        }
    }
}
