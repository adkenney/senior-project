using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Implement the pause as a global joint for later because click events still work and will commence
//After game is unpaused

public class PauseMenu : MonoBehaviour
{


    public static bool IsPaused = false;
    public GameObject PauseMenuUI;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsPaused)
            {
                FindObjectOfType<AudioManager>().Play("click_0");
                Resume();
            }
            else
            {
                FindObjectOfType<AudioManager>().Play("click_0");
                Pause();
            }
        }
    }

    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        IsPaused = false;
    }

    void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        IsPaused = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void loadSettings()
    {
        SceneManager.LoadScene("SettingsMenu", LoadSceneMode.Single);
    }
}