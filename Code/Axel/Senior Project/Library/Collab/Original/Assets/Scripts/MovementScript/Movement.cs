
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : TacticsMove
{
 

    public Animator animator;
    // Start is called before the first frame update
    protected static bool isPaused = false;
    

    
    void Start()
    {
        
        Time.timeScale = 1;
        Init();
        state = State.Idle;
    }

    // Update is called once per frame
    void Update()
    {

            
            if (state == State.Idle)
            {
                return;
            }

            if (state == State.Move)
            {
                if (!moving)
                {
                    FindSelectableTiles();
                    CheckMouse();
                }
                else
                {
                    Move();


                }
            }

            if (GetComponent<SpriteRenderer>().tag == "Player")
            {
                animator.SetBool("moving", moving);
            }




        if (state == State.Attack)
        {

            FindSelectableTiles();
            AttackSomeone();
        }



    }

    void CheckMouse()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 ray2dOrigin;
            Vector2 ray2dDirection;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            ray2dOrigin = ray.origin;
            ray2dDirection = ray.direction;
            RaycastHit2D hit = Physics2D.Raycast(ray2dOrigin, ray2dDirection);

            if (hit.collider)
            {
                if (hit.collider.tag == "Tile")
                {
                    Tiles t = hit.collider.GetComponent<Tiles>();

                    if (t.selectable)
                    {
                        MoveToTile(t);
                        
                    }

                }
               
            }
            
        }
        
    }
    void AttackSomeone()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Vector2 ray2dOrigin;
            Vector2 ray2dDirection;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            ray2dOrigin = ray.origin;
            ray2dDirection = ray.direction;
            LayerMask mask = LayerMask.GetMask("character");
            RaycastHit2D hit = Physics2D.Raycast(ray2dOrigin, ray2dDirection);

            if (hit.collider)
            {
                // collider check for enemy unit to attack -Arkell
                if (hit.collider.CompareTag("Enemy"))
                {

                    HurtEnemyUnit.Attack(hit);

                }
                HasAttacked();
                ActiveState();
                
            }
            
            
        }
    } 
    
    

}
