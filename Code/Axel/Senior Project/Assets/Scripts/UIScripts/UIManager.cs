using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
	GameObject[] pauseObjects;
	public static UIManager Instance;
	void Awake()
	{
		Instance = this;
	}

	// Use this for initialization
	void Start()
	{
		Time.timeScale = 1;
		pauseObjects = GameObject.FindGameObjectsWithTag("ShowOnPause");
		HidePaused();
	}

	// Update is called once per frame
	void Update()
	{

		//uses the p button to pause and unpause the game
		if (Input.GetKeyDown(KeyCode.P))
		{
			if (Time.timeScale == 1)
			{
				Debug.Log("Paused");
				Time.timeScale = 0;
				ShowPaused();
				
			}
			else if (Time.timeScale == 0)
			{
				Debug.Log("UnPaused");
				Time.timeScale = 1;
				HidePaused();
			}
		}
	}


	//Reloads the Level
	public void Reload()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		Debug.Log("Restarted Scene");
	}

	//controls the pausing of the scene
	public void PauseControl()
	{
		if (Time.timeScale == 1)
		{
			Time.timeScale = 0;
			ShowPaused();
		}
		else if (Time.timeScale == 0)
		{
			Time.timeScale = 1;
			HidePaused();
		}
	}

	//shows objects with ShowOnPause tag
	public void ShowPaused()
	{
		foreach (GameObject g in pauseObjects)
		{
			g.SetActive(true);
		}
	}

	//hides objects with ShowOnPause tag
	public void HidePaused()
	{
		foreach (GameObject g in pauseObjects)
		{
			g.SetActive(false);
		}
	}

	//loads inputted level
	public void LoadLevel(string level)
	{
		SceneManager.LoadScene(level);
	}
}
