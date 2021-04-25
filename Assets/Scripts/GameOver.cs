using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    Text final_score;

    bool overlay = false;

    float time_delay = 4f;
    // Start is called before the first frame update
    void Start()
    {
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
            Debug.Log ("Press command [c]");
            if(!overlay)
            {
                overlay=true;
                SceneManager.LoadSceneAsync("Commands", LoadSceneMode.Additive);
            }
        }
        else
        {
            Debug.Log ("Press not command [c]");
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

    public void DownloadTrack()
    {
    }
}
