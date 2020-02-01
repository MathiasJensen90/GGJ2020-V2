using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloodbank : MonoBehaviour
{
    public float RefillAmount;

    public void RefillBloodbag(Bloodbag bloodbag) {
        bloodbag.Remaining = bloodbag.Capacity;
    }
}