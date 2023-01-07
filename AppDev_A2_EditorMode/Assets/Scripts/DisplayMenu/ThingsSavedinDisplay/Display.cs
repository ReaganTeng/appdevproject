using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Display : MonoBehaviour
{
    public SaveDisplay save;

    public Toggle minimap;
    public Toggle health;
    public Toggle level;

    public Toggle small_controls;
    public Toggle medium_controls;
    public Toggle large_controls;


    public bool allow_map;
    public bool allow_hp;
    public bool allow_lvl;


    public bool allow_small_controls;
    public bool allow_medium_controls;
    public bool allow_large_controls;


    public bool IsUpdate;

    // Start is called before the first frame update
    void Start()
    {
        minimap.GetComponent<Toggle>().isOn = allow_map;
        health.GetComponent<Toggle>().isOn = allow_hp;
        level.GetComponent<Toggle>().isOn = allow_lvl;

        small_controls.GetComponent<Toggle>().isOn = allow_small_controls;
        medium_controls.GetComponent<Toggle>().isOn = allow_medium_controls;
        large_controls.GetComponent<Toggle>().isOn = allow_large_controls;

        IsUpdate = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsUpdate == true) //to prevent the game from updating the stats constantly
        {
            minimap.GetComponent<Toggle>().isOn = SaveDisplay.map_exist;
            health.GetComponent<Toggle>().isOn = SaveDisplay.hp_exist;
            level.GetComponent<Toggle>().isOn = SaveDisplay.lvl_exist;



            small_controls.GetComponent<Toggle>().isOn = SaveDisplay.small_exist;
            medium_controls.GetComponent<Toggle>().isOn = SaveDisplay.medium_exist;
            large_controls.GetComponent<Toggle>().isOn = SaveDisplay.large_exist;

            IsUpdate = false;
        }
    }


    public void GoToOptions()
    {
        save.SaveVariables();
        SceneManager.LoadScene("Audio or Visual");
    }
}
