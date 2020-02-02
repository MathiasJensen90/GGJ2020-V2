using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class GameOverManager : MonoBehaviour
{
    public ScoreManager ScoreManager;

    public TMPro.TextMeshProUGUI Text;

    public TMPro.TextMeshProUGUI[] HSText = new TMPro.TextMeshProUGUI[5];

    public HighscoreVariable Highscores;

    public SaveLoad SaveLoad;

    public void Awake() {
        SaveLoad = new SaveLoad();

        Text.text = $"You cured: {ScoreManager.PatientsCured}";

        SaveLoad.Highscores = Highscores;
        SaveLoad.Load();

        UpdateHighScores();
        
        for (int i = 0; i < HSText.Length; i++)
        {
            HSText[i].text = Highscores.HighscoreList.highscores[i].ToString();
        }

        
    }

    public void GoToMainMenu() {
        SceneManager.LoadScene("Menu");
    }

    public void UpdateHighScores()
    {
        if (Highscores.HighscoreList.highscores.Any(x => x < ScoreManager.PatientsCured)) {
            Highscores.HighscoreList.highscores[5] = ScoreManager.PatientsCured;
            Array.Sort(Highscores.HighscoreList.highscores);
        }

        SaveLoad.Save();
    }
}