using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameUIManager : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI scoreTextEngame;

    public Animator scoreTextAnimator;
    public void UpdateTimer(string value)
    {
        timerText.text = value;
    }

    public void UpdateScore(string value)
    {
        scoreTextAnimator.SetTrigger("Shake");
        scoreText.text = value;
        scoreTextEngame.text = value;
    }
}
