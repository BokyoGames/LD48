using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageReceiver : MonoBehaviour
{

    // TODO
    public int Health = 0;
    public int MaxHealth = 0;

    public SpriteRenderer life_bar;

    void OnDeath() {
        Debug.Log("We died");
    }

    public void SetHealthBarColor(Color healthColor)
    {
        life_bar.color = healthColor;
    }

    public void SetHealthBarValue(int value)
    {
        if(value < 2)
        {
            SetHealthBarColor(Color.red);
        }
        else if(value < 4)
        {
            SetHealthBarColor(Color.yellow);
        }
        else
        {
            SetHealthBarColor(Color.green);
        }
    }
 

    public void OnDamage(int damage) {
        Debug.Log(gameObject.name +": We got " + damage + " of damage.");
        if(Health - damage <= 0) {
            OnDeath();
        }
        Health -= damage;

        SetHealthBarValue(Health);
    }
}
