using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextManager : MonoBehaviour {

    public TextMeshProUGUI timerText;

    public string GetTimerText()
    {
        return timerText.text;
    }

    public void SetTimerText(string _text)
    {
        timerText.text = _text;
    }
}
