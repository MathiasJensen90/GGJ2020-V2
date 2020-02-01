using System;
using UnityEngine;


public class HighscoreManager : MonoBehaviour
{
    public float CountdownInSeconds = 60;

    public float PointFactor = 1f, PointMultiplier = 1f;

    public TMPro.TextMeshProUGUI Text;

    public GameEvent GameOver;

    void Awake() {
    }

    void Update() {
        var dt = new DateTime();
        dt = dt.AddSeconds(CountdownInSeconds);
        Text.text = dt.ToString("mm:ss");

        CountdownInSeconds -= Time.deltaTime * PointFactor * PointMultiplier;

        if (CountdownInSeconds < 0) GameOver.Raise();
    }
}