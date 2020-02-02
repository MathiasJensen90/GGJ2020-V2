using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavedPatientsDisplay : MonoBehaviour
{

    public TMPro.TextMeshProUGUI Text;
    public ScoreManager _SManager;

    // Update is called once per frame
    void Update()
    {
        Text.text = _SManager.PatientsCured.ToString();
    }
}
