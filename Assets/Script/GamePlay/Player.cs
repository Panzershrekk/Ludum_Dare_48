using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameManager GameManager;
    public PlayerControl PlayerControl;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (GameManager.GameStarted)
        {
            if (col.gameObject.GetComponent<Valuable>() != null)
            {
                Valuable val = col.gameObject.GetComponent<Valuable>();
                GameManager.AddScore(val.pointAwarded);
                val.PlayLootAnimation();
            }
        }
    }
}
