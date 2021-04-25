using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CableScale : MonoBehaviour
{
    public Transform startPos;
    public Transform endPos;

    // Update is called once per frame
    void Update()
    {
        Vector3 centerPos = new Vector3(startPos.position.x + endPos.position.x, 0) / 2f;
        float scale = Mathf.Abs(startPos.position.x - endPos.position.x);
        transform.position = centerPos;
        transform.localScale = new Vector3(scale, 1, 1);
    }
}
