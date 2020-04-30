using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    // Start is called before the first frame update
   
    
    private float moveX;
    private float moveY;

    [SerializeField]
    [Range(2,100)]
    private float speed;
    public Rigidbody2D player;
    public Rigidbody p;
    private Vector2 movement;
   

    void Start()
    {
       p = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        moveX = Input.GetAxis("Horizontal") * speed;
        moveY = Input.GetAxis("Vertical") * speed;
        movement = new Vector2(moveX,moveY);

        player.velocity = movement * speed;
    }

    void FixedUpdate()
    {
        moveCharacter(movement);
    }

    void moveCharacter(Vector2 dir)
    {
        player.MovePosition((Vector2)transform.position + (dir * speed * Time.deltaTime));
    }

}

/*

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    // Start is called before the first frame update
   
    
    private float moveX;
    private float moveY;

    [SerializeField]
    [Range(2,100)]
    public float speed;
    public Rigidbody2D player;
    private Vector2 movement;
    private Vector3 moveDir;
   

    void Start()
    {
       
    }

    private void Update(){
        HandleMovement();
    }

    private void HandleMovement(){
        float moveX = 0f;
        float moveY = 0f;

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            moveY = +1f;
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            moveY = -1f;
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            moveX = -1f;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            moveX = +1f;
        }
        moveDir = new Vector3(moveX,moveY).normalized;
    }

    private void OnTriggerEnter2D(Collider2D collider){
        Debug.Log("Hit the jig!");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        player.MovePosition(transform.position + moveDir * speed * Time.fixedDeltaTime);
    }

}



*/
