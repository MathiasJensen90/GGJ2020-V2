using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class ItemExample 
{

    public string name;
    public int id;
    public Sprite icon;

    public enum ItemType
    {
        None,
        Weapon,
        Consumable
    }

    public ItemType itemtype; 

}
