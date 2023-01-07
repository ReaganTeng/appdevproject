using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpandMap : MonoBehaviour
{
    static bool expanded = false;

    public GameObject ExpandedMapCam;
    public GameObject ExpandedMapWindow;

    public GameObject pause;
    public GameObject character_button;
    public GameObject joystick;
    public GameObject back_button;


    void Start()
    {
        expanded = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (!expanded)
        {
            ResumeGame();
        }
        else
        {
            Expand();
        }
    }

    public void ResumeGame()
    {
        pause.SetActive(true);
        joystick.SetActive(true);
        character_button.SetActive(true);

        ExpandedMapCam.SetActive(false);
        ExpandedMapWindow.SetActive(false);
        back_button.SetActive(false);

        Time.timeScale = 1.0f;
        expanded = false;
    }


    public void Expand()
    {
        pause.SetActive(false);
        joystick.SetActive(false);
        character_button.SetActive(false);

        ExpandedMapCam.SetActive(true);
        ExpandedMapWindow.SetActive(true);

        back_button.SetActive(true);


        Time.timeScale = 0.0f;
        expanded = true;
    }
}
