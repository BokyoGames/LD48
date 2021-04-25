using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDraggableCamera : MonoBehaviour
{

    public float DragSpeed = 2;

    void LateUpdate() {
        if (Input.GetMouseButton(1)) {

            var newPosition = new Vector3();

            //newPosition.x = Input.GetAxis("Mouse X") * DragSpeed * Time.deltaTime;
            newPosition.y = Input.GetAxis("Mouse Y") * DragSpeed * Time.deltaTime;

            // translates to the opposite direction of mouse position.
            transform.Translate(-newPosition);
        }
    }
}
