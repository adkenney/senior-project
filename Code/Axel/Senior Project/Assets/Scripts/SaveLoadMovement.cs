using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoadMovement:MonoBehaviour
{
    public GameObject player1;
    public GameObject enemy1;

    public GameObject player2;
    public GameObject enemy2;

    public GameObject player3;
    public GameObject enemy3;
    public GameObject camera;
   

    public void Save()
    {
        SaveSystem.saveData();
        Debug.Log("Pressed Save Button in Test");
    }

    public void Load()
    {
        BoardPlayerDataMovement data = SaveSystem.loadData();

        player1 = GameObject.Find ("character_maleAdventurer_idle (5)"); 
        player1.transform.position = new Vector3(data.playerA[0],data.playerA[1],data.playerA[2]);
        enemy1 = GameObject.Find ("character_maleAdventurer_idle (1)"); 
        enemy1.transform.position = new Vector3(data.enemyA[0],data.enemyA[1],data.enemyA[2]);

        Debug.Log("Loaded player A in Save LoadTest");

        player2 = GameObject.Find ("character_maleAdventurer_idle (4)"); 
        player2.transform.position = new Vector3(data.playerB[0],data.playerB[1],data.playerB[2]);
        enemy2 = GameObject.Find ("character_maleAdventurer_idle (2)"); 
        enemy2.transform.position = new Vector3(data.enemyB[0],data.enemyB[1],data.enemyB[2]);

        Debug.Log("Loaded player B in Save LoadTest");

        player3 = GameObject.Find ("character_maleAdventurer_idle"); 
        player3.transform.position = new Vector3(data.playerC[0],data.playerC[1],data.playerC[2]);
        enemy3 = GameObject.Find ("character_maleAdventurer_idle (3)"); 
        enemy1.transform.position = new Vector3(data.enemyC[0],data.enemyC[1],data.enemyC[2]);

        Debug.Log("Loaded player A in Save LoadTest");


        Debug.Log("Loaded Player and enemy");
        GameObject.Find("Main Camera").transform.position = new Vector3(data.cameraPos[0],data.cameraPos[1],data.cameraPos[2]);

        
    }
}
