using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patient : MonoBehaviour
{
    // How much blood to lose per second
    public float BloodLossRate = 5f;

    public float CureTimeout = 5f;

    public GameEvent PatientDead, PatientCured, ReplenishBB;

    public GameObject MountingPoint;

    public GameObject PatientAvatar;
    public BoxCollider2D Collider2D;

    public bool IsDead=false;

    public SpriteRenderer BloodSprite;

    public Item Item;

    public float Blood = 50f;

    public float MaxBlood = 100f;

    private float _bloodHeight;

    public ParticleSystem dyingParticles; 

    void Awake() {
        _bloodHeight = BloodSprite.size.y;
    }

    void Update()
    {
        if (!IsDead)
        {
            Blood -= BloodLossRate * Time.deltaTime;

            if (Blood <= 0f)
            {
                
                GetComponent<SpriteRenderer>().color = Color.black;
                IsDead = true;
                PatientDead?.Raise(this.gameObject);
            }

            BloodSprite.transform.localScale = Vector3.Lerp(new Vector3(1f, 0f, 1f), Vector3.one, Blood / MaxBlood);

            Item?.Effect(this);
        }

        
    }

    public void Heal(float healAmount)
    {
        Blood = Mathf.Min(Blood + healAmount, 100.0f);
    }

    public void Cure() {
        if (Item) {
            Destroy(Item.gameObject);
            ReplenishBB.Raise();
        }
        PatientCured.Raise(this.gameObject);
        StartCoroutine(CureRoutine());
    }

    private IEnumerator CureRoutine() {
        Collider2D.enabled = false;
        PatientAvatar.gameObject.SetActive(false);

        yield return new WaitForSeconds(CureTimeout);

        Collider2D.enabled = true;
        PatientAvatar.gameObject.SetActive(true);
    }


  
}
