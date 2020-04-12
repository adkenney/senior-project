using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alienMove : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    private float dirX;

    [SerializeField]
    [Range(2,100)]
    private float moveSpeed;
    private bool isMoving = false;
    private Vector3 targetPosition;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveSpeed = 100f;
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxis("Horizontal") * moveSpeed;
         if(Input.GetMouseButton(0))
        {
            SetTargetPosition();
        }

        if(isMoving)
        {
            move();
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(dirX,rb.velocity.y);
    }

        void move()
    {
        transform.rotation = Quaternion.LookRotation(Vector3.forward, targetPosition);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        if(transform.position == targetPosition){
            isMoving = false;
        } 
    }

    void SetTargetPosition()
    {
        targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        targetPosition.z = transform.position.z;
        isMoving = true;
    }

}
