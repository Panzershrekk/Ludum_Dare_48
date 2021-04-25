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
    public bool GameStarted = false;

    public float timeRemaining = 60;
    private bool _gameFinished = false;

    // Start is called before the first frame update
    void Start()
    {
        GameUIManager.UpdateTimer(Mathf.FloorToInt(timeRemaining).ToString());
    }

    // Update is called once per frame
    void Update()
    {
        if (_gameFinished == false && GameStarted == true)
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
        GameStarted = true;
        Player.PlayerControl.hasControl = true;
        //TODO Check to change this
        foreach (Element ele in FindObjectsOfType<Element>())
        {
            ele.CreationFinished = true;
        }
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
