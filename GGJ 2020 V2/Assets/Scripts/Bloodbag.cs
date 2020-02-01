using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloodbag : Item
{
    public float HealAmount = 33.0f;

    public override void Effect(Patient patient)
    {
        patient.Heal(HealAmount);
    }
    
}
