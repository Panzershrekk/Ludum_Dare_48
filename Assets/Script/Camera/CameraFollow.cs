using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    private void FixedUpdate()
    {
        /*Vector3 look = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = look - transform.position;
        direction.Normalize();*/

        Vector3 desiredPosition = target.position + offset /*+ direction * 2*/;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
