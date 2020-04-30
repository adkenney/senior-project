using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using Priority_Queue;

public class TurnManager : MonoBehaviour
{

    public static SimplePriorityQueue<TacticsMove> units = new SimplePriorityQueue<TacticsMove>();
    public static SimplePriorityQueue<TacticsMove> unitsRemaining = new SimplePriorityQueue<TacticsMove>();
    public static TacticsMove currentUnit;

    
    public static CinemachineVirtualCameraBase cam;
   
    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.Find("CM vcam1").GetComponent<CinemachineVirtualCameraBase>();
        StartCoroutine(MainCoroutine());
        
    }

    // Update is called once per frame
    void Update()
    {

        
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
                

                // Is being used in the HurtEnemyUnit script
                currentUnit = unitTurn; // variable to keep track of the current unit


                cam.LookAt = unitTurn.transform;
                cam.Follow = unitTurn.transform;

                unitTurn.BeginTurn();
                
                
            }
         
        }

    }

    public static void EndTurn(TacticsMove unit)
    {


        unit.prioritySpeed += units.Count;
        
        unit.EndTurn();

        if (unit.dead)
        {
            //do nothing
        }
        else
        {
            units.Enqueue(unit, unit.prioritySpeed);
        }
        if (units.Count > 0)
        {
            StartTurn();
        }
        
    }

    public static void AddUnit(TacticsMove unit)
    {
        
        units.Enqueue(unit, unit.prioritySpeed);
    }

    // to remove the unit from the turnKey once it is defeated if unit is last member to be defeated remove entire team
    public static void RemoveUnit()
    {
        
        Debug.Log("Works");
    }


    IEnumerator MainCoroutine()
    {

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSecondsRealtime(1.5f);
        StartTurn();

    }

}
