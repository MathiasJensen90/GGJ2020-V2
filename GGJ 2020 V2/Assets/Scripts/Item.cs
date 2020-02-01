using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    public bool IsTaken = false;
    public abstract void Effect(Patient patient);
}
