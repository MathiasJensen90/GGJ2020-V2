using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tray : MonoBehaviour
{
    public TraySpot[] Items;

    public Bloodbag Bloodbag;

    public void ReplenishOnce() {
        for (int i = 0; i < Items.Length; i++) {
            var spot = Items[i];

            if (spot.item == null) {
                spot.item = Instantiate(Bloodbag, spot.transform);
                spot.item.transform.localPosition = Vector2.zero;
                return;
            }
        }
    }
}