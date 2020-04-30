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
    public bool attackMode = false;



    public GameObject[] tiles;
    Color32 color = new Color32(50, 148, 162, 255);
    public float originOffset = 0.5f;

    //Needed A*
    public float f = 0;
    public float g = 0;
    public float h = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (current)
        {
            GetComponent<SpriteRenderer>().material.color = Color.yellow;
            
        }
        else if (target)
        {
            GetComponent<SpriteRenderer>().material.color = Color.green;

        }
        else if (selectable && attackMode)
        {
            GetComponent<SpriteRenderer>().material.color = color;

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
        attackMode = false;
        visited = false;
        parent = null;
        distance = 0;

        f = g = h = 0;

    }

    public void FindNeighbor(Tiles target)//added move and target
    {
        Reset();

        CheckTile(Vector2.left, target);
        CheckTile(Vector2.right, target);
        CheckTile(Vector2.up, target);
        CheckTile(Vector2.down, target);

    }

    //This function might need to include the raycast code 12:15
    public void CheckTile(Vector2 direction, Tiles target)
    {

        
        Collider2D[] colliders = Physics2D.OverlapBoxAll((Vector2)transform.position + direction, GetComponent<BoxCollider2D>().size, 1);

        foreach (Collider2D item in colliders)
        {
            if(item.tag == "Tile")
            {
                LayerMask obstacle = LayerMask.GetMask("obstactle");
                Tiles tile = item.GetComponent<Tiles>();
                RaycastHit2D hit = Physics2D.Raycast(tile.transform.position, Vector2.zero, 0,obstacle);
                if (tile != null && tile.walkable && !hit)
                {

                    
                     adjacencyList.Add(tile);
                    
                    
                }
            }
            
        }
    }

    
}
