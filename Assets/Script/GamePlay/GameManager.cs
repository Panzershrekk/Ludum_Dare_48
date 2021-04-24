using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameUIManager GameUIManager;
    public float PlayerScore;
    public float timeRemaining = 10;
    private bool _gameFinished = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (_gameFinished == false)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                GameUIManager.UpdateTimer(timeRemaining.ToString());
            }
            else
            {
                HandleGameEnd();
            }
        }
    }
    
    public void AddScore(float amount)
    {
        PlayerScore += amount;
        GameUIManager.UpdateScore(PlayerScore.ToString());
    }

    private void HandleGameEnd()
    {
        _gameFinished = true;
        timeRemaining = 0;
        GameUIManager.UpdateTimer(timeRemaining.ToString());

    }
}
