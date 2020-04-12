using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToLevel2 : MonoBehaviour
{
    // Start is called before the first frame update
  private int nextScene;

    void Start()
    {
        nextScene = SceneManager.GetActiveScene().buildIndex +1;
    }


    public void changeLevelScene(string sceneName){
        SceneManager.LoadScene(sceneName);
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene(6);
    }
}
