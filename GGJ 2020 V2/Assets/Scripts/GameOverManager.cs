using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public ScoreManager ScoreManager;

    public TMPro.TextMeshProUGUI Text;

    public TMPro.TextMeshProUGUI HSText;

    public void Awake() {
        Text.text = $"You cured: {ScoreManager.PatientsCured}";
        UpdateHighScores();
    }

    public void GoToMainMenu() {
        SceneManager.LoadScene("Menu");
    }

    public void UpdateHighScores()
    {
        HighscoreList.highscores[0].score = 5;

        HSText.text = HighscoreList.highscores.ToString();
    }
}