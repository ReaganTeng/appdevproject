using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalStats : MonoBehaviour
{
    public static GlobalStats Instance;
    public Character SavedCharacter = new Character();
    public MainGameVariables SavedWorld = new MainGameVariables();
    //"MAIN GAME" SCENE
    //player location
    public Vector3 location;
    //health bar
    public float healthlvl;
    //level up bar
    public float lvl;
    public bool is_it_saved;


    //for the controls
    public bool small_present;
    public bool medium_present;
    public bool large_present;


    //"AUDIO" SCENE
    public float sfx;
    public float soundtrack;


    //"DISPLAY" SCENE
    public bool minimap_present;
    public bool healthlvl_present;
    public bool lvl_present;

    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
}
