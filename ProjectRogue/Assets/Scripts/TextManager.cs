using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextManager : MonoBehaviour {

    public TextMeshProUGUI timerText;
    public TextMeshProUGUI causeOfDeathText;

    public string GetTimerText()
    {
        return timerText.text;
    }

    public void SetTimerText(string _text)
    {
        timerText.text = _text;
    }

    public string GetCODText()
    {
        return causeOfDeathText.text;
    }

    public void SetCODText(string _text)
    {
        causeOfDeathText.text = _text;
    }
}
