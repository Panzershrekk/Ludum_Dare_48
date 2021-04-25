using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAnimationScript : MonoBehaviour
{
    public GameManager manager;

    public void StartGame()
    {
        manager.StartGame();
    }
}
