using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMove : TacticsMove
{
    GameObject target;
    // Start is called before the first frame update

    void Start()
    {
        Time.timeScale = 1;
        Init();
    }

    // Update is called once per frame
    void Update()
    {

        
        if (state == State.Idle)
        {
            //EndturnState();
            return;
        }

        if (state == State.Move)
        {
            if (!moving)
            {
                FindNearestTarget();
                CalculatePath(); 
                FindSelectableTiles();
                actualTargetTile.target = true;
                //CheckMouse();
                
            }
            else
            {
                Move();

            }
        }

        /*if (state == State.Attack)
        {
            FindNearestTarget();
            //CalculatePath();
            FindSelectableTiles();
            actualTargetTile.target = true;
            //AttackSomeone();
        }*/
    }

    void CalculatePath()
    {
        
        Tiles targetTile = GetTargetTile(target);
        FindPath(targetTile);
    }

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

    void CalculateAttackTile()
    {
        Tiles targetTile = GetTargetTile(target);

    }
}
