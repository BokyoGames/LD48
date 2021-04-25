using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource Music;

    public List<AudioSource> MusicDepth;

    [Range(0,1)]
    public float MusicModifier;

    void Start() {
        Music.playOnAwake = true;
    }

    void Update()  {
        if(!Music.isPlaying)
            return;

        float maxVolume = Music.volume * MusicModifier;
        int depth = DataHandler.Handler.DepthReached;
        float layer1Step = 0.083f;
        float layer2Step = 0.125f;
        float layer3Step = 0.25f;
        if(depth == 0)
            return;
        if(depth <= 4) {
            MusicDepth[0].volume = maxVolume * layer1Step * depth;
        } else if(depth <= 8) {
            MusicDepth[0].volume = maxVolume * layer1Step * depth;
            MusicDepth[1].volume = maxVolume * layer2Step * (depth - 4);
        } else {
            MusicDepth[0].volume = maxVolume * layer1Step * depth;
            MusicDepth[1].volume = maxVolume * layer2Step * (depth - 4);
            MusicDepth[2].volume = maxVolume * layer3Step * (depth - 8);
        }
    }
}
