using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grapple : MonoBehaviour
{
    public float TimeToReach;

    public float TimeToGoBack;

    public float TimeToReachSurface;
    public Transform GrappleParent;
    public Player Player;
    private bool _grabbedSomething = false;
    private Vector2 _startingPosition = new Vector2(0, 0);
    private Coroutine _forwardGrab;
    private bool _forwardCoroutineRunning;
    private Vector2 _collidePoint;
    void Start()
    {
        _startingPosition = Player.transform.position;
    }

    public void TriggerGrapple(Vector2 finalPosition)
    {
        if (_forwardCoroutineRunning == false && _grabbedSomething == false)
        {
            _forwardGrab = StartCoroutine(GrappleForward(finalPosition));
        }
    }

    IEnumerator GrappleForward(Vector2 finalPosition)
    {
        _forwardCoroutineRunning = true;
        float elapsedTime = 0;

        while (elapsedTime < TimeToReach)
        {
            transform.position = Vector3.Lerp(_startingPosition, finalPosition, (elapsedTime / TimeToReach));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        _forwardCoroutineRunning = false;
        StartCoroutine(GrappleBackward());
    }

    IEnumerator GrappleBackward()
    {
        Vector3 currentPosition = transform.position;
        float elapsedTime = 0;

        while (elapsedTime < TimeToGoBack)
        {
            transform.position = Vector3.Lerp(currentPosition, _startingPosition, (elapsedTime / TimeToReach));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }

    IEnumerator GrappleSurface()
    {
        Player.PlayerControl.hasControl = false;
        transform.SetParent(null);
        Vector3 currentPosition = Player.transform.position;
        float elapsedTime = 0;

        while (elapsedTime < TimeToReachSurface)
        {
            Player.transform.localPosition = Vector3.Lerp(currentPosition, transform.localPosition, (elapsedTime / TimeToReach));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        transform.SetParent(GrappleParent);
        _grabbedSomething = false;
        Player.PlayerControl.hasControl = true;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.GetComponent<SolidStructure>() != null)
        {
            if (_forwardGrab != null)
            {
                StopCoroutine(_forwardGrab);
            }
            _forwardCoroutineRunning = false;
            _startingPosition = transform.position;
            _grabbedSomething = true;
            _collidePoint = col.ClosestPoint(Player.transform.position);
            StartCoroutine(GrappleSurface());
        }
    }
}
