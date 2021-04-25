using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource Music;

    void Start() {
        Music.playOnAwake = true;
    }
}
