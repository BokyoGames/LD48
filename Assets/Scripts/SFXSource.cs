using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXSource : MonoBehaviour
{
    public string Name;
    [HideInInspector]
    public AudioSource Source;
    public AudioClip clip;
    public GameObject AudioPrefabInstantiator;

    void Start () {
        //Source = GetComponent<AudioSource>();
        var tempObject = (Instantiate(AudioPrefabInstantiator));
        tempObject.transform.SetParent(this.transform);
        Source = tempObject.GetComponent<AudioSource>();
        Source.clip = clip;
    }
}
