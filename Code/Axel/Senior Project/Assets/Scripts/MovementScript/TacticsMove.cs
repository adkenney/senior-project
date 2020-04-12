using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TacticsMove : MonoBehaviour
{
    public bool turn = false;
    public bool dead = false;
    List<Tiles> selectableTile = new List<Tiles>();


    private GameObject[] tiles;

    Stack<Tiles> path = new Stack<Tiles>();
    private Tiles currentTile;
    public bool walking = false;
    public bool moving = false;
    public int move = 1;
    public int prioritySpeed = 1;
    public float moveSpeed = 1.0f;
    Vector2 velocity = new Vector2();
    Vector2 heading = new Vector2();

    public GameObject[] Tiles { get => tiles; set => tiles = value; }

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
        Vector2 position = target.transform.position;
        RaycastHit2D hit = Physics2D.Raycast(position, Vector2.up, .2f, 9);
        Tiles tile = null;
        
        if (hit.collider)
        {
            tile = hit.collider.GetComponent<Tiles>();
            
        }

        return tile;
    }

    public void ComputeAdjacencyList()
    {
        

        foreach (GameObject tile in Tiles)
        {
            Tiles t = tile.GetComponent<Tiles>();
            t.FindNeighbor();
        }
    }

    public void FindSelectableTiles()
    {
        ComputeAdjacencyList();
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
                Debug.Log(next.parent);
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
            // this is where the attack phase will happen
            TurnManager.EndTurn(this);
            // this is a movement end turn. we would normally end the turn after the unit action is complete but at the movement there is no combat
        }
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

    public void BeginTurn()
    {
        turn = true;
    }

    public void EndTurn()
    {
        turn = false;
    }
}
