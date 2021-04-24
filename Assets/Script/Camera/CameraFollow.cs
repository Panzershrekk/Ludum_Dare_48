using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
     public Camera MainCam;
     public GameObject player;
 
     private void FixedUpdate()
     {
         MainCam.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, MainCam.transform.position.z);
     }
}
