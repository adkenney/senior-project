using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionControl : MonoBehaviour
{

    public bool isActive = false;
    public GameObject ActionUI;
    public GameObject MoveUI;
    public GameObject AttackUI;

    public Movement unitMovement;
    

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (unitMovement.state == unitMovement.GetActiveState())
        {
            Resume();
        }
        else
        {

            Pause();
        }

        if(unitMovement.moved == true)
        {
            MoveUI.SetActive(false);
        }
        else
        {
            MoveUI.SetActive(true);
        }

        if (unitMovement.attacked == true)
        {
            AttackUI.SetActive(false);
        }
        else
        {
            AttackUI.SetActive(true);
        }



    }

    public void Resume()
    {
        ActionUI.SetActive(true);
        
    }

    void Pause()
    {
        ActionUI.SetActive(false); 


    }


}

