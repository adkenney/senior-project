using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LSplayerBoundary : MonoBehaviour
{
    private Vector2 screenBound;
    private float width;
    private float height;

    // Start is called before the first frame update
    void Start()
    {
        screenBound = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, screenBound.x, screenBound.x *-1 - width);
        viewPos.y = Mathf.Clamp(viewPos.y, screenBound.y, screenBound.y *-1 - height);
        transform.position = viewPos;
    }
}
