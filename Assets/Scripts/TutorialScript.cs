using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialScript : MonoBehaviour
{
    public float DisplayTime = 10f;
    public Text text_field;

    // Start is called before the first frame update
    public string[] tutorials = new string[] {
        "Dwarves can dig resources, which are needed for buildings. Sometimes they will also open a passage to a new layer while digging.", 
        "Houses are where new Dwarves grow. Send a Dwarf to a House to increase your population.", 
        "Deposits increase storage capacity. Taverns increase the amount of Dwarves that can live in your city.",
        "These mines are filled with hostile Goblins, slay them before you proceed!",
        "Sending Dwarves to the Masonry will let you recruit specialized Builders.",
        "Dwarves can go to the Barracks to train specialized Soldiers.",
        "",
        "Trolls in the cavern, be careful!",
        "Injured Dwarves can be sent to a Hospital to heal.",
        "",
        "Giant Spiders?! Prepare for an epic battle!",
        "",
        "You found Mithril! Defeat the monsters and dig as much as you can!"
    };
    // void Start() {
    //     Debug.Log("Start");
    //     DisplayTutorial();
    // }
    // void Awake() {
    //     Debug.Log("Awake");
    //     DisplayTutorial();
    // }

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
