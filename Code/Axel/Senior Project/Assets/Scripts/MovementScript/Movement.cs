

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : TacticsMove
{


    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
        Time.timeScale = 1;
        Init();

    }

    // Update is called once per frame
    void Update()
    {
        
        if (!turn)
        {
            return;
        }

        if (!moving)
        {
            FindSelectableTiles();
            CheckMouse();           
        }
        else
        {
            Move();

        }
       
        if (GetComponent<SpriteRenderer>().tag == "Player")
        {
            animator.SetBool("moving", moving);
        }
        
    }

    void CheckMouse()
    {
        
        if (Input.GetMouseButtonUp(0))
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
                // collider check for enemy unit to attack -Arkell
                else if (hit.collider.tag == "Enemy")
                {

                    HurtEnemyUnit.Attack(hit);

                }
            }
            //moving = true;
        }
    }

    
}
