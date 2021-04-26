using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    AudioSource[] start_sound;
    public Text button_text;

    bool overlay = false;

    float time_delay = 4f;
    // Start is called before the first frame update
    void Start()
    {
        start_sound = GetComponents<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("escape"))
        {
            Debug.Log ("Close the app [esc]");
            Application.Quit();
        }
        
        if(Input.GetKey("c"))
        {
            if(!overlay)
            {
                overlay=true;
                SceneManager.LoadSceneAsync("Commands", LoadSceneMode.Additive);
            }
        }
        else
        {
            if(overlay)
            {
                overlay=false;
                SceneManager.UnloadSceneAsync("Commands");
            }
        }
    }
    
    public void QuitGame()
    {
        // Debug.Log ("Close the app");
        // Application.Quit();
        // SceneManager.LoadSceneAsync("SampleScene", LoadSceneMode.Single);
    }

    public void EndNoDwarves()
    {
        Debug.Log ("Ending no dwarves!");
        SceneManager.LoadSceneAsync("EndNoDwarves", LoadSceneMode.Single);
    }

    public void EndGame()
    {
        Debug.Log ("Ending no dwarves!");
        SceneManager.LoadSceneAsync("EndBalrog", LoadSceneMode.Single);
    }


    public void StartGame()
    {
        start_sound[0].Play();
        button_text.text = "Loading...";
        SceneManager.LoadSceneAsync("MainGame", LoadSceneMode.Single);
    }
}
