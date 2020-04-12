using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class TestTile : MonoBehaviour
{
    public bool walkable = true;
    public bool current = false;
    public bool target = false;
    public bool selectable = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (current)
        {
            GetComponent<TilemapRenderer>().material.color = Color.white;
        }
        else if (target)
        {
            GetComponent<TilemapRenderer>().material.color = Color.clear;

        }
        else if (selectable)
        {
            GetComponent<TilemapRenderer>().material.color = Color.red;

        }
        else
        {
            GetComponent<TilemapRenderer>().material.color = Color.white;

        }

       
    }

    public void getTiles()
    {
        
    }
}
