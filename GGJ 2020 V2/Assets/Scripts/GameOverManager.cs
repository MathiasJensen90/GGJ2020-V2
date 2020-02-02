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
    }

    public void GoToMainMenu() {
        SceneManager.LoadScene("Menu");
    }

    public void UpdateHighScores()
    {
        var updating = Highscores.HighscoreList.highscores.Any(x => x < ScoreManager.PatientsCured);
        if (updating) {
            Highscores.HighscoreList.highscores[5] = ScoreManager.PatientsCured;
            Array.Sort(Highscores.HighscoreList.highscores);

            SaveLoad.Save();
        } 

        for (int i = 0; i < HSText.Length; i++)
        {
            HSText[i].text = Highscores.HighscoreList.highscores[i].ToString();
        }
        
        if (updating) {
            var index = Array.IndexOf(Highscores.HighscoreList.highscores, ScoreManager.PatientsCured);
            HSText[index].text = $"You cured: {HSText[index]}";
            HSText[index].gameObject.GetComponent<Animator>().enabled = true;
            Text.text = "";
        } else {
            Text.text = $"You cured: {ScoreManager.PatientsCured}";
            Text.gameObject.GetComponent<Animator>().enabled = true;
        }

    }
}