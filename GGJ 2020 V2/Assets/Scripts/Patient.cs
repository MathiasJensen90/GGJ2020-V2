using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patient : MonoBehaviour
{

    //sound

    public AudioClip[] dying = new AudioClip[3];
    public AudioClip[] curing = new AudioClip[4];
    public AudioClip[] ascending = new AudioClip[2]; 


    // How much blood to lose per second
    public float BloodLossRate = 5f;

    public float CureTimeout = 5f;


    public GameEvent PatientDead, PatientCured, ReplenishBB;

    public GameObject MountingPoint;

    public GameObject PatientAvatar;
    public BoxCollider2D Collider2D;

    public bool IsDead=false;

    public SpriteRenderer BloodSprite;
    public SpriteRenderer HighlightRenderer;

    public Item Item;

    public float Blood = 50f;

    public float MaxBlood = 100f;

    public float InitialBlood = 50f;

    private float _bloodHeight;

    private bool _over90;
    
    private HighscoreManager _HSManager;

    private Color _highlightColor;

    public ParticleSystem dyingParticles; 

    void Awake() {
        _bloodHeight = BloodSprite.size.y;
        Blood = InitialBlood;
        _HSManager = FindObjectOfType<HighscoreManager>();
        _highlightColor = HighlightRenderer.material.GetColor("_OutlineColor");
    }

    void Update()
    {
        if (!IsDead)
        {
            Blood -= BloodLossRate * Time.deltaTime* _HSManager.DifficultyMultiplier;

            if (Blood <= 0f)
            {
                
                IsDead = true;

                PatientDead?.Raise(this.gameObject);

                if (Item) {
                    Destroy(Item.gameObject);
                    ReplenishBB.Raise();
                }

                StartCoroutine(CureRoutine());
            }

            BloodSprite.transform.localScale = Vector3.Lerp(new Vector3(1f, 0f, 1f), Vector3.one, Blood / MaxBlood);

            Item?.Effect(this);

            if (!_over90 && Blood >= 90f) {
                HighlightRenderer.material.SetFloat("_OutlineThickness", 5);
                HighlightRenderer.material.SetColor("_OutlineColor", Color.green);
                _over90 = true;
            }

            if (_over90 && Blood < 90f) {
                print("oiiiiiii");
                HighlightRenderer.material.SetFloat("_OutlineThickness", 0);
                HighlightRenderer.material.SetColor("_OutlineColor", _highlightColor);
                _over90 = false;
            }
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

        Blood = InitialBlood;
        IsDead = false;
    }


    public void playDeathSound()
    {
           //Audio for death
                int randomClip = Random.Range(0, 3); 
                AudioSource.PlayClipAtPoint(dying[randomClip], transform.position, 0.5f);
              
    }


    public void playCureSound()
    {
        //Audio for curing
        int randomClip = Random.Range(0, 4);
        AudioSource.PlayClipAtPoint(curing[randomClip], transform.position, 1f);

        int randomClip2 = Random.Range(0, 2);
        AudioSource.PlayClipAtPoint(ascending[randomClip2], transform.position, 1f);

    }


}
