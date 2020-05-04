﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TacticsMove : MonoBehaviour
{
    public bool turn = false;
    public bool dead = false;
    List<Tiles> selectableTile = new List<Tiles>();
    public GameObject unit;

    public enum State
    {
        Idle,
        Active,
        Move,
        Attack
    }

    Stack<Tiles> path = new Stack<Tiles>();
    private Tiles currentTile;
    public bool walking = false;
    public bool moving = false;
    public bool moved = false;
    public bool attacked = false;
    public int move = 1;
    public int attackRange = 3;
    public int prioritySpeed = 1;
    public float moveSpeed = 1.0f;
    Vector2 velocity = new Vector2();
    Vector2 heading = new Vector2();
    public State state;
    public GameObject[] Tiles;

    public Tiles actualTargetTile;

    protected void Init(){

        Tiles = GameObject.FindGameObjectsWithTag("Tile");
        TurnManager.AddUnit(this);

    }

    public void GetCurrentTile()
    {
        currentTile = GetTargetTile(gameObject);
        
        currentTile.current = true;
    }

    public Tiles GetTargetTile(GameObject target)
    {
        
        RaycastHit2D hit = Physics2D.Raycast(target.transform.position, Vector3.up, .2f, 9);
        Tiles tile = null;
        
        if (hit.collider)
        {
            tile = hit.collider.GetComponent<Tiles>();
            
        }

        return tile;
    }

    public void ComputeAdjacencyList(Tiles target)//Added  target
    {
        

        foreach (GameObject tile in Tiles)
        {
            Tiles t = tile.GetComponent<Tiles>();
            t.FindNeighbor(target);//added target
        }
    }

    public void FindSelectableTiles()
    {
        ComputeAdjacencyList(null);//added null
        GetCurrentTile();


        //this is the bfs algorithm
        Queue<Tiles> process = new Queue<Tiles>();

        process.Enqueue(currentTile);
        currentTile.visited = true;
        //currentTile.parent = ?? leave as null

        while(process.Count > 0)
        {
            
            Tiles t = process.Dequeue();
            Vector2 position = t.transform.position;
            LayerMask mask = LayerMask.GetMask("character");
            LayerMask obstactleMask = LayerMask.GetMask("obstactle");
            RaycastHit2D hit = Physics2D.Raycast(position, Vector2.zero ,.2f, mask);
            RaycastHit2D obstactleHit = Physics2D.Raycast(position, Vector2.zero ,.2f, obstactleMask);

            if (state == State.Move)
            {
                if (!t.current && !hit.collider && !obstactleHit.collider)
                {
                    selectableTile.Add(t);
                    t.selectable = true;
                }


                if (t.distance < move)
                {
                    foreach (Tiles tile in t.adjacencyList)
                    {

                        RaycastHit2D hit2 = Physics2D.Raycast(tile.transform.position, Vector2.zero, .2f, obstactleMask);

                        if (!tile.visited && !hit2.collider)
                        {
                            tile.parent = t;
                            tile.visited = true;
                            tile.distance = 1 + t.distance;

                            process.Enqueue(tile);
                        }
                    }
                }
            }

            if(state == State.Attack)
            {
                if (!t.current && !obstactleHit.collider)
                {
                    selectableTile.Add(t);
                    t.selectable = true;
                    t.attackMode = true;
                }


                if (t.distance < attackRange)
                {
                    foreach (Tiles tile in t.adjacencyList)
                    {

                        RaycastHit2D hit2 = Physics2D.Raycast(tile.transform.position, Vector2.zero, .2f, obstactleMask);

                        if (!tile.visited && !hit2.collider)
                        {
                            tile.parent = t;
                            tile.visited = true;
                            tile.distance = 1 + t.distance;

                            process.Enqueue(tile);
                        }
                    }
                }
            }
            
        }

        

    }

    public void MoveToTile(Tiles tile)
    {
        
        path.Clear();
        tile.target = true;
        moving = true;
        Tiles next = tile;
        LayerMask obstactleMask = LayerMask.GetMask("obstactle");

        while (next != null)
        {
            RaycastHit2D obstactleHit = Physics2D.Raycast(next.transform.position, Vector2.zero, .2f, obstactleMask);
            if (obstactleHit.collider)
            {
                next = next.parent;
                
            }
            else
            {
                path.Push(next);
                next = next.parent;
            }
            
        }
    }

    public void Move()
    {
        if(path.Count > 0)
        {
            Tiles tile = path.Peek();
            Vector2 target = tile.transform.position;

            if(Vector2.Distance(transform.position, target) >= 0.3f)
            {
                CalculateHeading(target);
                SetHorizotalVelocity();

                //transform.up = heading;
                
                
                transform.position += (Vector3)velocity * Time.deltaTime;
                
            }
            else
            {
                //Tile center reached
                transform.position = target;
                path.Pop();
            }
        }
        else
        {
            RemoveSelectableTiles();
            
            moving = false;
            HasMoved();
            if(unit.tag == "Enemy")
            {
                EndturnState();
            }
            else
            {
                state = State.Active;
            }
            // this is where the attack phase will happen
            //TurnManager.EndTurn(this);
            // this is a movement end turn. we would normally end the turn after the unit action is complete but at the movement there is no combat
        }
    }

    public void AttackMode()
    {

    }


    protected void RemoveSelectableTiles()
    {

        if(currentTile != null)
        {
            currentTile.current = false;
            currentTile = null;
        }
        foreach(Tiles tile in selectableTile)
        {
            tile.Reset();
        }

        selectableTile.Clear();
    }

    void CalculateHeading(Vector2 target)
    {
        heading = target - (Vector2) transform.position;
        heading.Normalize();
    }

    void SetHorizotalVelocity()
    {
        velocity =  heading * moveSpeed;
        //velocity = moveSpeed;
    }

    protected Tiles FindLowestF(List<Tiles> list)
    {
        Tiles lowest = list[0];

        foreach (Tiles t in list)
        {
            if (t.f < lowest.f)
            {
                lowest = t;
            }
        }

        list.Remove(lowest);

        return lowest;
    }

    protected Tiles FindEndTile(Tiles t)
    {
        Stack<Tiles> tempPath = new Stack<Tiles>();

        Tiles next = t.parent;
        while(next !=  null)
        {
            tempPath.Push(next);
            next = next.parent;
        }

        if(tempPath.Count <= move)
        {
            return t.parent;
        }

        Tiles endTile = null;
        for(int i = 0; i <= move; i++)
        {
            endTile = tempPath.Pop();
        }

        return endTile;
    }
    protected Tiles FindAttackEndTile(Tiles t)
    {
        Stack<Tiles> tempPath = new Stack<Tiles>();

        Tiles next = t;
        while (next != null)
        {
            tempPath.Push(next);
            next = next.parent;
        }

        if (tempPath.Count <= move)
        {
            return t.parent;
        }

        Tiles endTile = null;
        for (int i = 0; i <= move; i++)
        {
            endTile = tempPath.Pop();
        }

        return endTile;
    }

    protected void FindPath(Tiles target)
    {
        ComputeAdjacencyList(target);
        GetCurrentTile();



        List<Tiles> openList = new List<Tiles>();
        List<Tiles> closedList = new List<Tiles>();

        openList.Add(currentTile);
        //currentTile.parent = ??
        currentTile.h = Vector2.Distance(currentTile.transform.position, target.transform.position);
        currentTile.f = currentTile.h;

        while (openList.Count > 0)
        {
            Tiles t = FindLowestF(openList);

            closedList.Add(t);
            if(state == State.Move)
            {
                if (t == target)
                {
                    actualTargetTile = FindEndTile(t);
                    MoveToTile(actualTargetTile);
                    return;
                }
            }

            if(state == State.Attack)
            {
                if (t == target)
                {
                    actualTargetTile = FindAttackEndTile(t);
                    Attack(actualTargetTile);
                    return;
                }
            }
            

            foreach (Tiles tile in t.adjacencyList)
            {
                if (closedList.Contains(tile))
                {
                    //Do nothing
                }
                else if(openList.Contains(tile))
                {
                    float tempG = t.g + Vector2.Distance(tile.transform.position, t.transform.position);

                    if(tempG < tile.g)
                    {
                        tile.parent = t;
                        tile.g = tempG;
                        tile.f = tile.g + tile.h;
                    }
                }
                else
                {
                    tile.parent = t;
                    tile.g = t.g + Vector2.Distance(tile.transform.position, t.transform.position);
                    tile.h = Vector2.Distance(tile.transform.position, target.transform.position);
                    tile.f = tile.g + tile.h;

                    openList.Add(tile);
                }
       
            }

        }

        // we will just skip the turn
        //if(openList.Count == 0)
        //todo - what happens if there is no path to the target tile
    }

    public void BeginTurn()
    {
        RestButtons();
        if(unit.tag == "Enemy")
        {
            state = State.Move;
        }
        else
        {
            state = State.Active;
        }
    }

    public void EndTurn()
    {
        RemoveSelectableTiles();
        state = State.Idle;
    }

    public void EndTurn2()
    {
        TurnManager.EndTurn(this);
    }

    public void MoveState()
    {
        state = State.Move;
    }
    public void AttackState()
    {
        state = State.Attack;
    }
    public void EndturnState()
    {
        RestButtons();
        TurnManager.EndTurn(this);
        
    }

    public State GetActiveState()
    {
        return State.Active;
    }

    public void ActiveState()
    {
        RemoveSelectableTiles();
        state = State.Active;
    }

    public void RestButtons()
    {
        moved = false;
        attacked = false;
    }

    public void HasAttacked()
    {
        attacked = true;
    }

    public void HasMoved()
    {
        moved = true;
    }

    public void Attack(Tiles tile)
    {
        LayerMask mask = LayerMask.GetMask("character");
        RaycastHit2D hit = Physics2D.Raycast(tile.transform.position, Vector2.zero, .2f, mask);
        if (hit)
        {
            /*if (hit.collider.tag == "Player")
            {
                UnitStats player = hit.collider.GetComponent<UnitStats>();
                EnemyUnitStats enemy = other.collider.GetComponent<EnemyUnitStats>();

                if (player.unitAttack <= enemy.unitDefense)
                {
                    currentDamage = 1;
                }
                else
                {
                    currentDamage = player.unitAttack - enemy.unitDefense;
                }
                enemy.GetComponent<PlayerHealth>().TakeDamage(currentDamage);
                Debug.Log("Hit " + enemy.name + " for " + currentDamage + " damage!");
            }*/

            Debug.Log(hit.collider.tag);
        }
        else
        {
            EndturnState();
        }

    }
}