using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Audio : MonoBehaviour
{
    public SaveAudio save;


    public Slider musiclvl;
    public Slider soundlvl;

    public float song;
    public float SFX;


    public bool IsUpdate;

    // Start is called before the first frame update
    void Start()
    { 
        song = musiclvl.value;
        SFX = soundlvl.value;



        IsUpdate = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsUpdate == true) //to prevent the game from updating the stats constantly
        { 
            musiclvl.value = SaveAudio.Music;
            soundlvl.value = SaveAudio.Sound;

            IsUpdate = false;
        }
    }


    


    public void GoToOptions()
    {
        save.SaveVariables();
        SceneManager.LoadScene("Audio or Visual");
    }
}
