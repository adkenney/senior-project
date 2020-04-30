using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{

    // Start is called before the first frame update
    public GameObject enemies;
    public GameObject players;
    public GameObject enemiesEndScreen;
    public GameObject playersEndScreen;
    private bool allEnemiesDead = false;
    private bool allPlayersDead = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    

    private void FixedUpdate()
    {
        allEnemiesActive();
        allPlayersActive();
        if (allEnemiesDead)
        {
            EnemiesEndScreen();
        }
        else if (allPlayersDead)
        {
            PlayersEndScreen();
        }

    }

    void allEnemiesActive()
    {
        foreach(Transform child in enemies.transform)
        {
            if (child.gameObject.activeSelf)
            {
                return;
            }
        }
        allEnemiesDead = true;
    }

    void allPlayersActive()
    {
        foreach (Transform child in players.transform)
        {
            if (child.gameObject.activeSelf)
            {
                return;
            }
        }
        allPlayersDead = true;
    }

    public void EnemiesEndScreen()
    {
        enemiesEndScreen.SetActive(true);
        Time.timeScale = 0f;
    }

    public void PlayersEndScreen()
    {
        playersEndScreen.SetActive(true);
        Time.timeScale = 0f;
    }



}
