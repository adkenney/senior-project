﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToLevel1 : MonoBehaviour
{
    // Update is called once per frame
     
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene("Movement", LoadSceneMode.Single);
        //Debug.Log("Enter Level one");

    }
}
