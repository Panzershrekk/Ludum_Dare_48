using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grapple : MonoBehaviour
{
    public float TimeToReach;

    public float TimeToGoBack;
    public AudioSource GrabAudio;
    public float TimeToReachSurface;
    public Transform GrappleParent;
    public Player Player;
    private bool _grabbedSomething = false;
    private Vector2 _startingPosition = new Vector2(0, 0);
    private Coroutine _forwardGrab;
    private bool _forwardCoroutineRunning;
    private Vector2 _collidePoint;
    private Vector2 _localOrigin;
    private Vector2 _origin;
    private bool _grabStarted;
    private SolidStructure _currentGrabbedSolidStructure = null;
    void Start()
    {
        _startingPosition = Player.transform.position;
        _localOrigin = transform.localPosition;
        _origin = transform.position;
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
        transform.SetParent(null);
        Player.PlayerControl.hasControl = false;
        _forwardCoroutineRunning = true;
        float elapsedTime = 0;
        _grabStarted = true;
        _startingPosition = transform.position;
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
        _grabStarted = false;
        Vector3 currentPosition = transform.localPosition;
        float elapsedTime = 0;

        while (elapsedTime < TimeToGoBack)
        {
            transform.localPosition = Vector3.Lerp(currentPosition, _startingPosition, (elapsedTime / TimeToReach));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        transform.SetParent(GrappleParent);
        Player.PlayerControl.hasControl = true;
    }

    IEnumerator GrappleSurface()
    {
        GrabAudio.Play();
        Vector3 currentPosition = Player.transform.position;
        float elapsedTime = 0;

        while (elapsedTime < TimeToReachSurface)
        {
            Player.transform.position = Vector3.Lerp(currentPosition, transform.position, (elapsedTime / TimeToReach));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        transform.SetParent(GrappleParent);
        transform.localPosition = _localOrigin;
        _grabbedSomething = false;
        Player.PlayerControl.hasControl = true;
        _grabStarted = false;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (_grabStarted == true)
        {
            if (col.gameObject.GetComponent<SolidStructure>() != null)
            {
                SolidStructure tmpStruct = col.gameObject.GetComponent<SolidStructure>();
                if (tmpStruct != _currentGrabbedSolidStructure)
                {
                    _currentGrabbedSolidStructure = tmpStruct;
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
    }
}
