using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavedPatientsDisplay : MonoBehaviour
{

    public TMPro.TextMeshProUGUI Text;
    public ScoreManager _SManager;

    // Start is called before the first frame update
    void Awake()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateText()
    {
        Text.text = _SManager.PatientsCured.ToString();
    }

}
