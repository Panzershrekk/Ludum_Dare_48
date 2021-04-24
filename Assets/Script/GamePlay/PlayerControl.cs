using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public bool hasControl = false;
    public float grabRange = 1;
    public GameObject GrapplePivot;
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
        LookAt2D();
        Vector2 direction = (Vector2)((_lookedPosition - transform.position));
        direction.Normalize();

        _grabMaxPosition = (Vector2)transform.position + direction * grabRange;
        if (Input.GetMouseButtonDown(0))
        {
            Grapple.TriggerGrapple(_grabMaxPosition);
        }
    }

    private void LookAt2D()
    {
        Vector3 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(GrapplePivot.transform.position);
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        GrapplePivot.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, _lookedPosition);
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, _grabMaxPosition);
    }
}
