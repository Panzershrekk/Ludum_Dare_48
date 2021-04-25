using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameUIManager GameUIManager;
    public Player Player;
    public GameObject EndGameUI;
    public AudioSource AudioSource;
    public float PlayerScore;
    public float timeRemaining = 60;
    private bool _gameStarted = false;
    private bool _gameFinished = false;

    // Start is called before the first frame update
    void Start()
    {
        GameUIManager.UpdateTimer(Mathf.FloorToInt(timeRemaining).ToString());
    }

    // Update is called once per frame
    void Update()
    {
        if (_gameFinished == false && _gameStarted == true)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                GameUIManager.UpdateTimer(Mathf.FloorToInt(timeRemaining).ToString());
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

    public void StartGame()
    {
        _gameStarted = true;
        Player.PlayerControl.hasControl = true;
    }

    private void HandleGameEnd()
    {
        AudioSource.volume /= 2f;
        _gameFinished = true;
        timeRemaining = 0;
        GameUIManager.UpdateTimer(Mathf.FloorToInt(timeRemaining).ToString());
        Player.PlayerControl.hasControl = false;
        Player.PlayerControl.enabled = false;
        EndGameUI.SetActive(true);
    }
}
