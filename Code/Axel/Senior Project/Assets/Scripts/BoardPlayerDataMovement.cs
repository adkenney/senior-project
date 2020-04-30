using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BoardPlayerDataMovement
{
    
    public float[] playerA;
    public float[] enemyA;

    public float[] playerB;
    public float[] enemyB;

    public float[] playerC;
    public float[] enemyC;
    
    public float[] cameraPos;
    

    //public GameObject enemyList;

    public BoardPlayerDataMovement ()
    {

        
        playerA = new float[3];
        playerA[0] = GameObject.Find("character_maleAdventurer_idle (5)").transform.position.x;
        playerA[1] = GameObject.Find("character_maleAdventurer_idle (5)").transform.position.y;
        playerA[2] = GameObject.Find("character_maleAdventurer_idle (5)").transform.position.z;
        
        enemyA = new float[3];
        enemyA[0] = GameObject.Find("character_maleAdventurer_idle (1)").transform.position.x;
        enemyA[1] = GameObject.Find("character_maleAdventurer_idle (1)").transform.position.y;
        enemyA[2] = GameObject.Find("character_maleAdventurer_idle (1)").transform.position.z;

        Debug.Log("Made it through P/E A!");

        playerB = new float[3];
        playerB[0] = GameObject.Find("character_maleAdventurer_idle (4)").transform.position.x;
        playerB[1] = GameObject.Find("character_maleAdventurer_idle (4)").transform.position.y;
        playerB[2] = GameObject.Find("character_maleAdventurer_idle (4)").transform.position.z;
        
        enemyB = new float[3];
        enemyB[0] = GameObject.Find("character_maleAdventurer_idle (2)").transform.position.x;
        enemyB[1] = GameObject.Find("character_maleAdventurer_idle (2)").transform.position.y;
        enemyB[2] = GameObject.Find("character_maleAdventurer_idle (2)").transform.position.z;

        Debug.Log("Made it through P/E B!");

        playerC = new float[3];
        playerC[0] = GameObject.Find("character_maleAdventurer_idle").transform.position.x;
        playerC[1] = GameObject.Find("character_maleAdventurer_idle").transform.position.y;
        playerC[2] = GameObject.Find("character_maleAdventurer_idle").transform.position.z;
        
        enemyC = new float[3];
        enemyC[0] = GameObject.Find("character_maleAdventurer_idle (3)").transform.position.x;
        enemyC[1] = GameObject.Find("character_maleAdventurer_idle (3)").transform.position.y;
        enemyC[2] = GameObject.Find("character_maleAdventurer_idle (3)").transform.position.z;
        
        Debug.Log("Made it through P/E C!");

        cameraPos = new float[3];
        cameraPos[0] = Camera.main.transform.position.x;
        cameraPos[1] = Camera.main.transform.position.y;
        cameraPos[2] = Camera.main.transform.position.z;

         Debug.Log("Made it to the camera!");
        
    }


}


