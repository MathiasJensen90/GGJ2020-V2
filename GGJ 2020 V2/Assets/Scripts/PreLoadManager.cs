using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PreLoadManager : MonoBehaviour
{
    public ScoreManager ScoreManager;
    public HighscoreVariable Highscore;

    public static PreLoadManager Instance;

    void Start() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(this);
        } else {
            DestroyImmediate(this);
        }

        SceneManager.LoadScene("Menu");
    }
}
