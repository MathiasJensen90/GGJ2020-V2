using UnityEngine;

public class HighscoreManager : MonoBehaviour
{
    public float TimeInSeconds;

    public float PointFactor = 1f, PointMultiplier = 1f;

    void Awake() {
        TimeInSeconds = 0f;
    }

    void Update() {
        TimeInSeconds += Time.deltaTime * PointFactor * PointMultiplier;
    }
}