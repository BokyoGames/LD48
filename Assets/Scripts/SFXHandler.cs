using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXHandler : MonoBehaviour
{

    [Range(0, 4000)]
    public float SfxIntervalRandomizer = 0f;

    public float BattleSFXInterval;
    private float lastBattleSFX = 0f;

    public float AttackSFXInterval;
    private float lastAttackSFX = 0f;

    public float SpawnSFXInterval;
    private float lastSpawnSFX = 0f;

    public float EnemyGruntSFXInterval;
    private float lastEnemyGruntSFX = 0f;

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

    bool CanPlayGeneric(float interval, float last, bool randomizer = false) {
        if(randomizer) {
            float value = Random.Range(-1 * SfxIntervalRandomizer / 2 , SfxIntervalRandomizer / 2);
            return (Time.time - last) * 1000 > (interval + value);
        }
        else
            return (Time.time - last) * 1000 > interval;
    }

    public bool CanPlayBattleSFX {
        get {
            if(CanPlayGeneric(BattleSFXInterval, lastBattleSFX)) { 
                lastBattleSFX = Time.time;
                return true;
            }
            return false;
        }
    }

    public bool CanPlayAttackSFX {
        get {
            if(CanPlayGeneric(AttackSFXInterval, lastAttackSFX)) { 
                lastAttackSFX = Time.time;
                return true;
            }
            return false;
        }
    }

    public bool CanPlaySpawnSFX {
        get {
            if(CanPlayGeneric(SpawnSFXInterval, lastSpawnSFX)) { 
                lastSpawnSFX = Time.time;
                return true;
            }
            return false;
        }
    }
    public bool CanPlayEnemyGruntSFX {
        get {
            if(CanPlayGeneric(EnemyGruntSFXInterval, lastEnemyGruntSFX, true)) { 
                lastEnemyGruntSFX = Time.time;
                return true;
            }
            return false;
        }
    }
}

