using UnityEngine;
using System.Collections;

public class ClickSound : MonoBehaviour
{
    public AudioSource sound;

    private void Start()
    {
      
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            sound.Play();
        }
    }
}