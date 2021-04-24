using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int amountOfPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.GetComponent<Valuable>() != null)
        {
            Valuable val = col.gameObject.GetComponent<Valuable>();
            amountOfPoint += val.pointAwarded;
            Destroy(col.gameObject);
        }
    }
}
