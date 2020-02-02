using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickSound : MonoBehaviour
{

    public AudioClip[] clickSound = new AudioClip[3];
 

    
    public void Playclick()
    {
        int randomInt = Random.Range(0, clickSound.Length);
        AudioSource.PlayClipAtPoint(clickSound[randomInt], transform.position, 0.5f);
    }
}
