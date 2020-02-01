using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraySpot : MonoBehaviour
{
    public Item item;

    private void Awake()
    {
        if (item != null)
        {
            item = Instantiate(item, transform);
            item.transform.localPosition = Vector2.zero;
        }
    }

    private void Update()
    {
        if(item != null)
        {
            GetComponent<SpriteRenderer>().sprite = item.GetComponent<SpriteRenderer>().sprite;
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = null;
        }
    }
}
