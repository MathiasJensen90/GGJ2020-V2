using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patient : MonoBehaviour
{
    // How much blood to lose per second
    public float BloodLossRate = 5f;

    public GameEvent PatientDead;

    public SpriteRenderer BloodSprite;

    public Item Item;

    public float Blood = 100f;

    public float MaxBlood = 100f;

    private float _bloodHeight;

    void Awake() {
        _bloodHeight = BloodSprite.size.y;
    }

    void Update()
    {
        Blood -= BloodLossRate * Time.deltaTime;

        if (Blood <= 0f) {
            PatientDead.Raise();
        }

        BloodSprite.size = Vector2.Lerp(new Vector2(BloodSprite.size.x, 0f), new Vector2(BloodSprite.size.x, _bloodHeight), Blood / MaxBlood);

        Item?.Effect(this);
    }

    public void Heal(float healAmount)
    {
        Blood = Mathf.Min(Blood + healAmount, 100.0f);
    }
}
