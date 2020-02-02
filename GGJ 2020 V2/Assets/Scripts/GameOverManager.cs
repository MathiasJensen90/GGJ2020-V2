using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public ScoreManager ScoreManager;

    public TMPro.TextMeshProUGUI Text;

    public void Awake() {
        Text.text = $"You cured: {ScoreManager.PatientsCured}";
    }

    public void GoToMainMenu() {
        SceneManager.LoadScene("Menu");
    }
}