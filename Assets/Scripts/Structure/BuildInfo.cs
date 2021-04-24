using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildInfo : MonoBehaviour
{
    public StructureType type;
    private PanelStateHandler player_state_handler;

    public void OnSelect() {
        player_state_handler.OnSelect(type);
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
