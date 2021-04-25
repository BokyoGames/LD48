using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialScript : MonoBehaviour
{
    public int DisplayTime = 5000;
    public Text text_field;

    // Start is called before the first frame update
    public string[] tutorials = new string[] {
        "Click on the dwarf and on a target and tell him to go dig", 
        "You can build houses so more dwarves can move into your city\nClick on the dwarf and on a building target and tell him what to build.", 
        "Some special houses let you spawn new units. Try building one and assigning one of your dwarves to operate it.",
        "Be careful! You never know what you’ll find the deeper you dig.\nTo attact an enemy select a dwarf and an enemy and click use to attack.",
        "If you are injured, try building a hospital.",
        "Some units can specialize in building or fighting, allocate your resources carefully.",
        "Never dig straight down."
    };

    public void DisplayTutorial()
    {
        if(DataHandler.Handler.DepthReached < tutorials.Length)
        {
            gameObject.SetActive(true);
            text_field.text =  tutorials[DataHandler.Handler.DepthReached];

            Invoke("HideTutorial", 10f);
        }
    }

    private void HideTutorial()
    {
        gameObject.SetActive(false);
    }

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
