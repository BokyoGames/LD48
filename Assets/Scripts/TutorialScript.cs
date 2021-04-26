using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialScript : MonoBehaviour
{
    public float DisplayTime = 10f;
    public Text text_field;

    // Start is called before the first frame update
    public string[] tutorials;

    void Start() {
        Debug.Log("Start");
        DisplayTutorial();
    }

    public void DisplayTutorial() {
        if(DataHandler.Handler.DepthReached < tutorials.Length) {
            if(tutorials[DataHandler.Handler.DepthReached] != "") {
                gameObject.SetActive(true);
                SFXHandler.GetInstance().PlayFX("ui_message");
                text_field.text =  tutorials[DataHandler.Handler.DepthReached];

                Invoke("HideTutorial", DisplayTime);
            }
        }
    }

    private void HideTutorial() {
        gameObject.SetActive(false);
    }
}
