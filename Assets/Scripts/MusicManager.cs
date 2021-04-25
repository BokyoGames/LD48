using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource Music;

    public List<AudioSource> MusicDepth;

    void Start() {
        Music.playOnAwake = true;
    }

    void Update()  {
        if(!Music.isPlaying)
            return;
        //for(int i = 0; i < MusicDepth.Count; i++) {

        //}
    }
}
