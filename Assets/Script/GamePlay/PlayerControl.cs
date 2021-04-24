using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float grabRange = 1;
    public Grapple Grapple;
    private Vector2 _lookedPosition = new Vector2();
    private Vector2 _grabMaxPosition = new Vector2();

    void Start()
    {

    }

    void Update()
    {
        MouseControl();
    }

    //COULD BE EXTENDED TO MORE CONTROL, SEE TO IT
    private void MouseControl()
    {
        _lookedPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _grabMaxPosition = _lookedPosition;
        //_grabMaxPosition = (_lookedPosition - (Vector2) transform.localPosition).normalized;
        if (Input.GetMouseButtonDown(0))
        {
            Grapple.TriggerGrapple(_grabMaxPosition);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, _lookedPosition);
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, _grabMaxPosition);
    }
}
