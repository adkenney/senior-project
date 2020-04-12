using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    private  SceneHandler scene;
void Awake()
     {
        DontDestroyOnLoad(gameObject);
        scene = GameObject.FindGameObjectWithTag("SceneHandler").GetComponent<SceneHandler>();
        scene.SaveScene();
     }

 
     public void SaveScene()
     {
         int activeScene = SceneManager.GetActiveScene().buildIndex;
         PlayerPrefs.SetInt("ActiveScene", activeScene);
     }
 
     public void LoadScene()
     {
         int activeScene = PlayerPrefs.GetInt("ActiveScene");
         StartCoroutine(LoadNewScene(activeScene));
     }
 
     IEnumerator LoadNewScene(int sceneBuildIndex)
     {
         AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneBuildIndex);
         asyncOperation.allowSceneActivation = false;
         while (asyncOperation.progress < 0.9f)
         {
             yield return null;
         }
         asyncOperation.allowSceneActivation = true;

     }
 }

