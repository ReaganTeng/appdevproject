using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    static bool paused = false;

    public GameObject pauseUI;

    void Start()
    {
        paused = false;
    }
        // Update is called once per frame
        void Update()
    {
        if(!paused)
        {
            Resume();
        }
        else
        {
            Pausing();
        }
    }

    public void Resume()
    {
        pauseUI.SetActive(false);
        Time.timeScale = 1.0f;
        paused = false;
    }


    public void Pausing()
    {
        pauseUI.SetActive(true);
        Time.timeScale = 0.0f;
        paused = true;
    }
}
