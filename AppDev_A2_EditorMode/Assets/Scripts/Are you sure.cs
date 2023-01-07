using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Areyousure : MonoBehaviour
{
    public static bool sure = false;

    public GameObject quitUI;

    // Update is called once per frame
    void Update()
    {
        if (!sure)
        {
            NO();
        }
        else
        {
            Pausing();
        }
    }

    public void NO()
    {
        quitUI.SetActive(false);
        Time.timeScale = 1.0f;
        sure = false;
    }


    public void Pausing()
    {
        quitUI.SetActive(true);
        Time.timeScale = 0.0f;
        sure = true;
    }


    public void YES()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
