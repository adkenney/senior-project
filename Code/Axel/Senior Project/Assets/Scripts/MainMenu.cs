using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   public void PlayGame(){
       Debug.Log(SceneManager.GetSceneByName("Movement"));
       SceneManager.LoadScene("LevelSelect", LoadSceneMode.Single);
   }

   public void QuitGame(){
       Debug.Log("Quit");
       Application.Quit();
   }

    private void Start()
    {
        //FindObjectOfType<AudioManager>().Play("Cardinal_Wind");
    }
}
