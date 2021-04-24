using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public bool hasControl = false;
    public float grabRange = 1;
    public Grapple Grapple;
    private Vector3 _lookedPosition;
    private Vector3 _grabMaxPosition;

    void Update()
    {
        if (hasControl == true)
        {
            MouseControl();
        }
    }

    //COULD BE EXTENDED TO MORE CONTROL, SEE TO IT
    private void MouseControl()
    {
        _lookedPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (Vector2)((_lookedPosition - transform.position));
        direction.Normalize();

        _grabMaxPosition = direction * grabRange;
        if (Input.GetMouseButtonDown(0))
        {
            Grapple.TriggerGrapple(_lookedPosition);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, _lookedPosition);
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position, _grabMaxPosition);
    }
}
