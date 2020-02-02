using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ScoreManager : ScriptableObject
{
    public int PatientsCured = 0;
    public int PatientsDied = 0;

    public void IncrementCured() {
        PatientsCured++;
    }

    public void IncrementDied() {
        PatientsDied++;
    }

    public void ResetScore() {
        PatientsCured = 0;
        PatientsDied = 0;
    }
}