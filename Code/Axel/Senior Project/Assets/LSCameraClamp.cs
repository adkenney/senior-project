using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LSCameraClamp : MonoBehaviour
{
     [SerializeField]
    private Transform targetToFollow;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(
            Mathf.Clamp(targetToFollow.position.x, minX,maxX),
            Mathf.Clamp(targetToFollow.position.y, minY,maxY),
            transform.position.z
        );
    }
}
