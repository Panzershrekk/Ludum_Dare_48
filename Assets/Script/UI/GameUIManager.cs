using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameUIManager : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI scoreText;

    public void UpdateTimer(string value)
    {
        timerText.text = value;
    }

    public void UpdateScore(string value)
    {
        scoreText.text = value;
    }
}
