using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Implement the pause as a global joint for later because click events still work and will commence
//After game is unpaused

public class PauseScreen : MonoBehaviour {


	public static bool IsPaused = false;
	public GameObject PauseMenuUI;
	

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown(KeyCode.Escape)) 
		{
			if(IsPaused)
			{
				Resume();
			}else{
				Pause();
			}
		}
	}

void Resume(){
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

}