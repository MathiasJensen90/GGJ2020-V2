using System;
using UnityEngine;


public class HighscoreManager : MonoBehaviour
{
    //Difficulty variables
    public float BaseDifficultyMultiplier = 1f;

    public float DifficultyMultiplier = 0f;

    [Tooltip("Time for difficulty multiplier to increase by 1")]
    public float TimeForDifficultyIncrease = 20f;

    private float _playTime = 0f;


    //Timer variables
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

        _playTime += Time.deltaTime;

        DifficultyMultiplier = BaseDifficultyMultiplier + _playTime / TimeForDifficultyIncrease;
    }

    public void AddTimeToTimer(float time)
    {
        CountdownInSeconds += time;
    }
}