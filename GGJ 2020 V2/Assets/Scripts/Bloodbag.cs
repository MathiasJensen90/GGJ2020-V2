using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloodbag : Item
{
    public float HealAmount = 33.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Effect(Patient patient)
    {
        patient.Heal(HealAmount);
    }
    
}
