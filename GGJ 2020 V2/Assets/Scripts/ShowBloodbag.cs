using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowBloodbag : MonoBehaviour
{
    public Patient patient;
    private SpriteRenderer spriteRenderer;

    public void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    // Update is called once per frame
    void Update()
    {
        if (patient.Item != null)
        {
            spriteRenderer.enabled = true;
        }
        else
        {
            spriteRenderer.enabled = false;
        }
    }
}
