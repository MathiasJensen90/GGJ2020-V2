using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patient : MonoBehaviour
{

    //sound

    public AudioClip[] dying = new AudioClip[3];
    public AudioClip[] curing = new AudioClip[4];


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

    public float InitialBlood = 50f;

    private float _bloodHeight;
    
    private HighscoreManager _HSManager;

    public ParticleSystem dyingParticles; 

    void Awake() {
        _bloodHeight = BloodSprite.size.y;
        Blood = InitialBlood;
        _HSManager = FindObjectOfType<HighscoreManager>();
    }

    void Update()
    {
        if (!IsDead)
        {
            Blood -= BloodLossRate * Time.deltaTime* _HSManager.DifficultyMultiplier;

            if (Blood <= 0f)
            {
                
                IsDead = true;
                
                    //Audio for death
                int randomClip = Random.Range(0, 3); 
                AudioSource.PlayClipAtPoint(dying[randomClip], transform.position, 0.1f);
                PatientDead?.Raise(this.gameObject);

                if (Item) {
                    Destroy(Item.gameObject);
                    ReplenishBB.Raise();
                }

                StartCoroutine(CureRoutine());
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

        //Audio for curing
        int randomClip = Random.Range(0, 4);
        AudioSource.PlayClipAtPoint(curing[randomClip], transform.position, 0.2f);
        PatientDead?.Raise(this.gameObject);

        yield return new WaitForSeconds(CureTimeout);

        Collider2D.enabled = true;
        PatientAvatar.gameObject.SetActive(true);

        Blood = InitialBlood;
        IsDead = false;
    }
}
