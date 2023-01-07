using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class CharacterXY : MonoBehaviour
{
    public SaveMainGame save;


    public Camera character;

    public Slider HPbar;
    public Slider LVLbar;
    public float HP;
    public float Level;


    public bool saving;
    public Toggle save_fire;




    public bool IsUpdate;



    public GameObject PauseUI;


    // Start is called before the first frame update
    void Start()
    {
        character = Camera.main;

        HP = HPbar.value;
        Level = LVLbar.value;

        saving = save_fire.GetComponent<Toggle>().isOn;



        IsUpdate = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsUpdate == true) //to prevent the game from updating the stats constantly
        {
            Camera.main.transform.position = SaveMainGame.CXY;

            HPbar.value = SaveMainGame.Health;
            LVLbar.value = SaveMainGame.LVL;

            save_fire.GetComponent<Toggle>().isOn = SaveMainGame.saved;

        

            IsUpdate = false;
        }
    }


    public void GoToInventory()
    {
        save.SaveVariables();
        SceneManager.LoadScene("Character");
    }

    public void GoToMainGame()
    {
        if (save_fire.GetComponent<Toggle>().isOn == true)
        {
            save.SaveVariables();
        }

        SceneManager.LoadScene("Main Menu");
    }

    public void GoToMainGame2()
    {
        save.SaveVariables();
        

        SceneManager.LoadScene("Main Game");
    }



    public void GoToQuitSCreen()
    {
        PauseUI.SetActive(true);
    }


    public void GoToOptions()
    {
        save.SaveVariables();
        SceneManager.LoadScene("Audio or Visual");
    }
}
