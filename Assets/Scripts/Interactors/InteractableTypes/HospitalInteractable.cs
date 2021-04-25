using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HospitalInteractable : AbstractInteractableLogic
{
    public int healing_capacity = 10;

    public override void OnTick() 
    {
        if(interactors.Count > 0) 
        {
            foreach (Interactor element in interactors)
            {
                var damage_receiver = element.gameObject.GetComponent<DamageReceiver>();
                damage_receiver.OnHeal(healing_capacity);
            }
        }
    }
}
