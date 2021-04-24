using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildInfo : MonoBehaviour
{
    public GameObject structure;
    private PanelStateHandler player_state_handler;


    public void OnSelect() {
        player_state_handler.OnSelect(structure);
    }

    // Start is called before the first frame update
    void Start()
    {
        player_state_handler = GameObject.FindGameObjectWithTag("Player").GetComponent<PanelStateHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
