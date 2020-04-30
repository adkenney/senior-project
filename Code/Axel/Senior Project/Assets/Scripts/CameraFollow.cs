using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
     public Transform playerObj;

    void FixedUpdate()
    {
        transform.position = new Vector3(playerObj.position.x,playerObj.position.y,playerObj.position.z);
    }
}
