using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Priority_Queue;

public class TurnManager : MonoBehaviour
{

    static Dictionary<string, List<TacticsMove>> unitss = new Dictionary<string, List<TacticsMove>>();
    static Queue<string> turnKey = new Queue<string>();
    static SimplePriorityQueue<TacticsMove> units = new SimplePriorityQueue<TacticsMove>();


    // Start is called before the first frame update
    void Start()
    {

        /*turnKey.Enqueue("Player");
        turnKey.Enqueue("Enemy");*/
        StartTurn();
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if(units.Count == 0)
        {
            InitTeamTurnQueue();
           
        }*/
        
    }

    static void InitTeamTurnQueue()
    {
        /*List<TacticsMove> teamList = unitss[turnKey.Peek()];
        
        foreach (TacticsMove unit in teamList)
        {
            if (!unit.dead)
            {
                turnTeam.Enqueue(unit);
                //Debug.Log(unit.tag);
            }
            
     
        }*/

        
    }

    static void StartTurn()
    {   
        
        if (units.Count > 0)
        {
            
            TacticsMove unitTurn = units.Dequeue();
            if (unitTurn.dead)
            {
                StartTurn();
            }
            else
            {
                Camera.main.transform.position = new Vector3(unitTurn.transform.position.x, unitTurn.transform.position.y, Camera.main.transform.position.z);
                unitTurn.BeginTurn();
                
            }
         
        }
        /*else
        {
            turnKey.Dequeue();
        }*/


    }

    public static void EndTurn(TacticsMove unit)
    {
        /*TacticsMove unit = turnTeam.Dequeue();*/

        unit.prioritySpeed += units.Count;
        unit.EndTurn();
        units.Enqueue(unit, unit.prioritySpeed);

        if(units.Count > 0)
        {
            StartTurn();
        }
        /*else
        {
            string team = turnKey.Dequeue();
            //Debug.Log(team);
            turnKey.Enqueue(team);
            InitTeamTurnQueue();
        }*/
    }

    public static void AddUnit(TacticsMove unit)
    {
        /*List<TacticsMove> list;
        if (!unitss.ContainsKey(unit.tag))
        {
            list = new List<TacticsMove>();
            unitss[unit.tag] = list;
            
        }
        else
        {
            list = unitss[unit.tag];
        }
       
        list.Add(unit);*/
        units.Enqueue(unit, unit.prioritySpeed);
    }

    // to remove the unit from the turnKey once it is defeated if unit is last member to be defeated remove entire team
    public static void RemoveUnit()
    {
        int numberTurnKey = turnKey.Count;
        //Debug.Log(turnKey.Peek() + numberTurnKey);
    }
}
