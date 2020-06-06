using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class GameMenu : MonoBehaviour
{
    private bool paused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!paused)
            {
                Time.timeScale = 0f;
                paused = true;
            }
            
            else
            {
                Time.timeScale = 1f;
                paused = false;
            }
        }
    }
}