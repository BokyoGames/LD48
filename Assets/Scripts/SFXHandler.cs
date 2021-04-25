using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXHandler : MonoBehaviour
{
    public static SFXHandler GetInstance() {
        return GameObject.FindGameObjectsWithTag("SoundManager")[0].GetComponent<SFXHandler>();
    }

    Dictionary<string, SFXSource> SFXs = new Dictionary<string, SFXSource>();

    // Start is called before the first frame update
    void Start() {
        var sources = GetComponentsInChildren<SFXSource>();
        foreach(var s in sources) {
            SFXs.Add(s.Name, s);
        }
    }

    public void PlayFX(string name, bool loop = false) {
        if(!SFXs.ContainsKey(name)) {
            throw new UnityException("SFX does not exist or has not been loaded: " + name);
        }
        var fx = SFXs[name].Source;
        if(!loop) {
            fx.PlayOneShot(fx.clip);
        } else {
            if(!fx.isPlaying) {
                fx.loop = true;
                fx.Play();
            }
        }
    }

    public void StopFX(string name) {
        if(!SFXs.ContainsKey(name)) {
            throw new UnityException("SFX does not exist or has not been loaded: " + name);
        }
        var fx = SFXs[name].Source;
        if(fx.isPlaying && !fx.loop) {
            Debug.Log("We tried to stop a non-looping FX");
        }
        if(fx.isPlaying && fx.loop) {
            fx.loop = false;
            fx.Stop();
        }
    }

    public bool IsFXPlaying(string name) {
        if(!SFXs.ContainsKey(name)) {
            throw new UnityException("SFX does not exist or has not been loaded: " + name);
        }
        return SFXs[name].Source.isPlaying;
    }
}

