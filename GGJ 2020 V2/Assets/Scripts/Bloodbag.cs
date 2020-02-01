using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloodbag : Item
{
    public float Capacity = 33f;
    public float Remaining = 0f;

    public float HealAmount = 5f;

    [SerializeField]
    private SpriteRenderer SpriteRenderer;

    void Update() {
        SpriteRenderer.size = Vector2.Lerp(new Vector2(1f, 0f), new Vector2(1f, 1f), Remaining / Capacity);
    }

    public override void Effect(Patient patient)
    {
        var frameHealAmount = HealAmount * Time.deltaTime;
        if (Remaining > frameHealAmount) {
            
            patient.Heal(frameHealAmount);
            Remaining -= frameHealAmount;
        } else if (Remaining > 0f) {
            patient.Heal(Remaining);
            Remaining = 0f;
        }
    }  
}
