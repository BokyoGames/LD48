using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInText : MonoBehaviour
{

    public float wait_time = 10f;
    public float fade_in_time = 10f;

    private Text text;
    // Start is called before the first frame update
    void Start()
    {
        text = gameObject.GetComponent<Text>();
        text.CrossFadeAlpha(0f, 0f, false);
        Invoke("Fade", wait_time);
    }

    void Fade()
    {
        text.CrossFadeAlpha(1f, fade_in_time, false);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
