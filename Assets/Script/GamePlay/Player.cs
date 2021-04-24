using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameManager GameManager;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.GetComponent<Valuable>() != null)
        {
            Valuable val = col.gameObject.GetComponent<Valuable>();
            GameManager.AddScore(val.pointAwarded);
            Destroy(col.gameObject);
        }
    }
}
