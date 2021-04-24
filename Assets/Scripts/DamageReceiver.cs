using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageReceiver : MonoBehaviour
{

    // TODO
    public int Health = 0;
    public int MaxHealth = 0;

    void OnDeath() {
        Debug.Log("We died");
    }

    public void OnDamage(int damage) {
        Debug.Log(gameObject.name +": We got " + damage + " of damage.");
        if(Health - damage <= 0) {
            OnDeath();
        }
        Health -= damage;
    }
}
