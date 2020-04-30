
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

            
        if (state == State.Idle || dead)
        {
            return;
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            ActiveState();
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
            

            
            LayerMask mask = LayerMask.GetMask("character");
            RaycastHit2D[] hit = Physics2D.RaycastAll(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero,mask);

            if (hit[0])
            {
               /* if (hit[0].collider.CompareTag("Tile"))
                {
                    Tiles tiles = hit[0].collider.GetComponent<Tiles>();
                    if (tiles.selectable)
                    {

                    }
                }*/

                
                //Debug.Log(hit[0].collider.tag);
                foreach(RaycastHit2D colliderHit in hit)
                {
                    Debug.Log(colliderHit.collider.tag);
                    if (colliderHit.collider.CompareTag("Enemy"))
                    {

                        HurtEnemyUnit.Attack(colliderHit);
                        HasAttacked();
                        ActiveState();
                    }
                    
                }
                // collider check for enemy unit to attack -Arkell
                /*if (hit[0].collider.CompareTag("Enemy"))
                {
                    
                    HurtEnemyUnit.Attack(hit[0]);
                    HasAttacked();
                    ActiveState();
                }*/
                //HasAttacked();
                //ActiveState();
                
            }
            
            
        }
    } 
    
    

}
