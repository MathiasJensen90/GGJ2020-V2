using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloodbag : Item
{
    public float Capacity = 33f;
    public float Remaining = 0f;

    public float HealAmount = 5f;

    public override void Effect(Patient patient)
    {
        if (Remaining > HealAmount * Time.deltaTime) {
            patient.Heal(HealAmount);
            Remaining -= HealAmount * Time.deltaTime;
        } else if (Remaining > 0f) {
            patient.Heal(Remaining);
            Remaining = 0f;
        }
    }  
}
