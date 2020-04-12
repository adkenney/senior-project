using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiles : MonoBehaviour

{
    public bool walkable = true;
    public bool current = false;
    public bool target = false;
    public bool selectable = false;

    public List<Tiles> adjacencyList = new List<Tiles>();


    //Needed BFS (breadth first search_)
    public bool visited = false;
    public Tiles parent = null;
    public int distance = 0;

    public GameObject[] tiles;

    public float originOffset = 0.5f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (current)
        {
            GetComponent<SpriteRenderer>().material.color = Color.white;
            
        }
        else if (target)
        {
            GetComponent<SpriteRenderer>().material.color = Color.green;

        }
        else if (selectable)
        {
            GetComponent<SpriteRenderer>().material.color = Color.red;

        }
        else
        {
            GetComponent<SpriteRenderer>().material.color = Color.white;

        }
    }

    public void Reset()
    {
        adjacencyList.Clear();

        current = false;
        target = false;
        selectable = false;

        visited = false;
        parent = null;
        distance = 0;

    }

    public void FindNeighbor()
    {
        Reset();

        CheckTile(Vector2.left);
        CheckTile(Vector2.right);
        CheckTile(Vector2.up);
        CheckTile(Vector2.down);

    }

    public void CheckTile(Vector2 direction)
    {

        
        Collider2D[] colliders = Physics2D.OverlapBoxAll((Vector2)transform.position + direction, GetComponent<BoxCollider2D>().size, 1);

        foreach (Collider2D item in colliders)
        {
            if(item.tag == "Tile")
            {
                Tiles tile = item.GetComponent<Tiles>();

                if (tile != null && tile.walkable)
                {

                    adjacencyList.Add(tile);
                }
            }
            
        }
    }

    
}
