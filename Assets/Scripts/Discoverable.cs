using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Discoverable : MonoBehaviour
{
    public Rigidbody2D CaveCover;
    public Transform Ladder;
    public Transform ActiveObjects;

    private LayerHandler handler;

    void Start() {
        handler = GameObject.FindGameObjectWithTag("LayerHandler").GetComponent<LayerHandler>();
    }

    public bool IsDiscovered() {
        return !CaveCover.gameObject.activeInHierarchy;
    }

    public void Discover() {
        Debug.Log("We've been discovered");
        // Disable the layer, we now have a new discovered object
        if(CaveCover.gameObject.activeInHierarchy) {
            CaveCover.gameObject.SetActive(false);
        }
        if(ActiveObjects != null && !ActiveObjects.gameObject.activeInHierarchy) {
            ActiveObjects.gameObject.SetActive(true);
            DataHandler.Handler.DepthReached++;
            
            GameObject.FindGameObjectWithTag("Player").GetComponent<PanelStateHandler>().TutorialHandler.GetComponent<TutorialScript>().DisplayTutorial();
        }
        // TODO - Send events to other listeners that the layer has been discovered
    }

    public void DebugFlipActiveAndCover() {
        CaveCover.gameObject.SetActive(!CaveCover.gameObject.activeInHierarchy);
        ActiveObjects.gameObject.SetActive(!ActiveObjects.gameObject.activeInHierarchy);
    }
}

 #if UNITY_EDITOR
[UnityEditor.CustomEditor(typeof(Discoverable))]
public class DiscoverableEditor : UnityEditor.Editor {
    override public void OnInspectorGUI() {
        Discoverable discoverableCreator = (Discoverable)target;
        if(GUILayout.Button("FlipDiscoveredState")) {
            discoverableCreator.DebugFlipActiveAndCover();
        }
        DrawDefaultInspector();
    }
}

#endif 
