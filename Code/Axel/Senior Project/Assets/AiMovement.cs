
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AiMovement : TacticsMove
{


    public Animator animator;
    // Start is called before the first frame update

    GameObject target;


    private void Awake()
    {
        state = State.Idle;
    }
    void Start()
    {

        Time.timeScale = 1;
        Init();

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(state);
        if (state == State.Idle)
        {
            return;
        }

        if (state == State.Move)
        {
            if (!moving)
            {
                FindNearestTarget();
                CalculatePath();
                FindSelectableTiles();
                //actualTargetTile.target = true;
            }
            else
            {
                Move();
            }
        }

        void CalculatePath()
        {
            Tiles targetTile = GetTargetTile(target);
            //FindPath(targetTile);
        }

        //Function to find the nearest target
        void FindNearestTarget()
        {
            GameObject[] targets = GameObject.FindGameObjectsWithTag("Player");

            GameObject nearest = null;
            float distance = Mathf.Infinity;

            foreach(GameObject obj in targets)
            {
                float d = Vector2.Distance(transform.position, obj.transform.position);

                if (d < distance)
                {
                    distance = d;
                    nearest = obj;
                }
            }

            target = nearest;
        }

        //if (GetComponent<SpriteRenderer>().tag == "Player")
        //{
        //    animator.SetBool("moving", moving);
        //}

    }

}
