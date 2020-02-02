using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteJuice : MonoBehaviour
{

  


    public void startCour()
    {
        StartCoroutine(hereIsJuice()); 
    }


    private IEnumerator hereIsJuice ()
        {
        yield return new WaitForSeconds(3);
        gameObject.SetActive(false); 
        }

  
}
