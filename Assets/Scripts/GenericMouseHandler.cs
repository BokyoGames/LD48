using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GenericMouseHandler : MonoBehaviour
{
    // TODO: It'd be nice to have this code to work, but it doesn't and you can just ignore it for now don't worry
    // Update is called once per frame
    void Update() {
        // Nothing to be done
        if(!Input.GetMouseButtonDown(0))
            return;


        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        if(hit.collider != null) {
            if(hit.collider.gameObject.layer == LayerMask.NameToLayer("AnimateObjects")) {
                return;
            }
            return;
        }
    }
}
