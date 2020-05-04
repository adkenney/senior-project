using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public GameObject howToMenu;
    public GameObject mainMenu;
    public GameObject optionsMenu;


    void Start()
    {
        
   
    }
    public void PlayGame(){
       Debug.Log(SceneManager.GetSceneByName("Movement"));
        SceneManager.LoadScene("LevelSelect", LoadSceneMode.Single);
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }


    public void ToHowToMenu()
    {
        mainMenu.SetActive(false);
        howToMenu.SetActive(true);
        
        
    }
    public void BackToMainMenu()
    {
        howToMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void LoadOptions()
    {
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);

    }
}
