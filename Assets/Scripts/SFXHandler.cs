using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXHandler : MonoBehaviour
{
    public float BattleSFXInterval;
    private float lastBattleSFX = 0f;

    public float AttackSFXInterval;
    private float lastAttackSFX = 0f;

    public float SpawnSFXInterval;
    private float lastSpawnSFX = 0f;

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

    public void PlayRandomFX(string[] list) {
        var randomIndex = Random.Range(0, list.Length);
        PlayFX(list[randomIndex]);
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

    public bool CanPlayBattleSFX {
        get {
            if((Time.time - lastBattleSFX) * 1000 > BattleSFXInterval) {
                lastBattleSFX = Time.time;
                return true;
            }
            return false;
        }
    }

    public bool CanPlayAttackSFX {
        get {
            if((Time.time - lastAttackSFX) * 1000 > AttackSFXInterval) {
                lastAttackSFX = Time.time;
                return true;
            }
            return false;
        }
    }

    public bool CanPlaySpawnSFX {
        get {
            if((Time.time - lastSpawnSFX) * 1000 > SpawnSFXInterval) {
                lastSpawnSFX = Time.time;
                return true;
            }
            return false;
        }
    }
}

