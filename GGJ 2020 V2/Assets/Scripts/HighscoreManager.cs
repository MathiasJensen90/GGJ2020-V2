using System;
using UnityEngine;


public class HighscoreManager : MonoBehaviour
{
    //Difficulty variables
    public float BaseDifficultyMultiplier = 1f;

    public float DifficultyMultiplier = 0f;

    [Tooltip("Time for difficulty multiplier to increase by 1")]
    public float TimeForDifficultyIncrease = 20f;

    public AudioSource CountdownClip;

    private float _playTime = 0f;

    //Timer variables
    public float CountdownInSeconds = 60;

    public float PointFactor = 1f, PointMultiplier = 1f;

    private bool _under10 = false;

    public TMPro.TextMeshProUGUI Text;

    public GameEvent GameOver;

    void Awake() {
    }

    void Update() {
        var dt = new DateTime();
        dt = dt.AddSeconds(Mathf.Max(CountdownInSeconds,0));
        Text.text = dt.ToString("mm:ss");

        CountdownInSeconds -= Time.deltaTime * PointFactor * PointMultiplier;

        if (CountdownInSeconds < 0) GameOver.Raise();

        _playTime += Time.deltaTime;

        DifficultyMultiplier = BaseDifficultyMultiplier + _playTime / TimeForDifficultyIncrease;

        if (_under10 && CountdownInSeconds > 10f) {
            CountdownClip.Stop();
            _under10 = false;
        }
        if (!_under10 && CountdownInSeconds < 10f && CountdownInSeconds > 0f) {
            CountdownClip.time = (10f - CountdownInSeconds);
            CountdownClip.Play();
            _under10 = true;
        }
    }

    public void AddTimeToTimer(float time)
    {
        CountdownInSeconds += time;
        CountdownClip.time = (10f - CountdownInSeconds);
    }
}