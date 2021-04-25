using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageReceiver : MonoBehaviour
{

    // TODO
    public int Health = 0;
    public int MaxHealth = 0;
    bool weAlreadyDied = false;

    float originalLifeBarScaleX = 0;

    public SpriteRenderer life_bar;

    void Start() {
        originalLifeBarScaleX = life_bar.transform.localScale.x;
    }

    void OnDeath() {
        weAlreadyDied = true;
        GetComponent<AbstractSelectable>().OnDeath();
        // TODO Handle death here
    }

    public void SetHealthBarColor(Color healthColor) {
        life_bar.color = healthColor;
    }

    public void UpdateHealthBarValue() {
        if(Health < MaxHealth / 4) {
            SetHealthBarColor(Color.red);
        }
        else if(Health < MaxHealth / 2) {
            SetHealthBarColor(Color.yellow);
        }
        else {
            SetHealthBarColor(Color.green);
        }

        if(Health == MaxHealth || Health == 0) {
            life_bar.enabled = false;
        } else {
            life_bar.enabled = true;
        }

        Vector3 scale = life_bar.transform.localScale;
        scale.x = originalLifeBarScaleX * ((float)Health / (float)MaxHealth);
        life_bar.transform.localScale = scale;
    }
 

    public void OnDamage(GameObject enemy, int damage) {
        if(weAlreadyDied)
            return;

        var interactor = this.GetComponent<Interactor>();
        if(interactor)
        {
            interactor.StartCombat(enemy.GetComponent<Enemy>());
        }

        Debug.Log(gameObject.name +": We got " + damage + " of damage.");
        Health -= damage;
        if(Health - damage <= 0) {
            OnDeath();
            Health = 0;
        }
        UpdateHealthBarValue();
    }

    public void OnHeal(int heal) 
    {
        if(weAlreadyDied)
            return;
        Debug.Log(gameObject.name +": We got " + heal + " of heal.");
        Health += heal;
        if(Health > MaxHealth) 
        {
            Health = MaxHealth;
        }
        UpdateHealthBarValue();
    }
}
