using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Element : MonoBehaviour
{
    public bool CreationFinished = false;
    void OnTriggerEnter2D(Collider2D col)
    {
        if (CreationFinished == false)
        {
            if (col.GetComponent<Element>() != null)
            {
                col.GetComponent<Element>().CreationFinished = true;
                Destroy(gameObject);
            }
        }
    }
}
