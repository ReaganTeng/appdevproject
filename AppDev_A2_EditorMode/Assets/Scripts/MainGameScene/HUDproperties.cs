using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDproperties : MonoBehaviour
{

    public static HUDproperties Instance;

    static bool paused = false;

    public GameObject pauseUI;

    public GameObject healthbar;


    //FOR THE MINIMAP
    public GameObject minimapbutton;
    public GameObject minimaplayout;
    public GameObject playerpos;

    //FOR CLEAVE ABILITY
    public Image[] cleave;
    float timeRemaining_cleave;
    bool timerIsRunning_cleave;
    public Text[] cleaveText;

    //FOR FIRE ABILITY
    public Image[] fireball;
    float timeRemaining_fireball;
    bool timerIsRunning_fireball;
    public Text[] fireballText;

    //FOR MAGIC ABILITY
    public Image[] magic;
    float timeRemaining_magic;
    bool timerIsRunning_magic;
    public Text[] magicText;

    //FOR HEART ABILITY
    public Image[] heart;
    float timeRemaining_heart;
    bool timerIsRunning_heart;
    public Text[] heartText;

    //FOR LEVEL UP BAR
    public GameObject lvlbar;
    public Slider lvlup;
    float timer_level;
    bool showrequirements;
    public GameObject lvlrequirements;
    float fillSpeed = 10;
    public float max_requirement;
    int lvl_number = 1;
    public Text level_number;
    public Text levelrequirements;
    

    //SWITCH ABILITIES
    bool new_set;


    //CONTROLLER SIZE
    public GameObject small;
    public GameObject medium;
    public GameObject large;

    //FOR NOTIFICATIONS
    public GameObject notifications;
    

    //SAVE POINT
    public Toggle fire;
    public GameObject unsaved;
    public GameObject saved;
    bool saved_or_not;

    //THERE ARE 3 CONTROLLER SIZES
    int limit;

    void Start()
    {
        Set();

        saved_or_not = false;
        //IF SMALL CONTROLS ENABLED IN "DISPLAY" SCENE
        if (GlobalStats.Instance.small_present == false)
        {
            small.SetActive(false);
        }

        //IF MEDIUM CONTROLS ENABLED IN "DISPLAY" SCENE
        if (GlobalStats.Instance.medium_present == false)
        {
            medium.SetActive(false);
        }

        //IF LARGE CONTROLS ENABLED IN "DISPLAY" SCENE
        if (GlobalStats.Instance.large_present == false)
        {
            large.SetActive(false);
        }

        limit = 3;
        max_requirement = 10000;

        showrequirements = false;
        timer_level = 5;

        new_set = false;


        lvlrequirements.SetActive(false);

        //IF HEALTHBAR IS SET NOT PRESENT IN "DISPLAY" SCENE
        if (GlobalStats.Instance.healthlvl_present == false)
        {
            healthbar.SetActive(false);
        }

        //IF LVL UP BAR IS SET NOT PRESENT IN "DISPLAY" SCENE
        if (GlobalStats.Instance.lvl_present == false)
        {
            lvlbar.SetActive(false);

        }
        else
        {
            lvlbar.SetActive(true);
        }

        //IF MINI MAP IS SET NOT PRESENT IN "DISPLAY" SCENE
        if (GlobalStats.Instance.minimap_present == false)
        {
            minimapbutton.SetActive(false);
            minimaplayout.SetActive(false);
            playerpos.SetActive(false);

        }

        
    }

    //RESET EVERYTHING IF ABILITIES ARE SWITCHED
    void Set()
    {
        for (int i = 0; i < limit; i++)
        {
            cleaveText[i].enabled = false;
            heartText[i].enabled = false;
            fireballText[i].enabled = false;
            magicText[i].enabled = false;
        }

        timerIsRunning_fireball = false;
        timerIsRunning_cleave = false;
        timerIsRunning_magic = false;
        timerIsRunning_heart = false;


        timeRemaining_cleave = 11;
        timeRemaining_heart = 6;
        timeRemaining_fireball = 21;
        timeRemaining_magic = 16;
    }


   


    // Update is called once per frame
    void Update()
    {
        //FOR SAVE POINT
        if(fire.GetComponent<Toggle>().isOn == true)
        {

            unsaved.SetActive(false);
            saved.SetActive(true);
            saved_or_not = true;
        }
        else
        {
           

            unsaved.SetActive(true);
            saved.SetActive(false);
            saved_or_not = false;
        }

        //IF THE GAME IS NOT PAUSED
        if (!paused)
        {
            //CONTINUOUSLY ANIMATE THE BAR
            if (lvlup.value < max_requirement)
            {
                lvlup.value += fillSpeed;

                
            }
            else
            {
                lvl_number += 1;
                max_requirement *= 2;
                lvlup.value = 0;
                
            }


            //WHEN TO PRINT OUT NOTIFICATIONS
            if(lvlup.value < 2000 && max_requirement != 10000)
            {
                 notifications.SetActive(true);
            }
            else
            {
                notifications.SetActive(false);
            }






        int max_requirement_int = (int)max_requirement;
            string lvl_require = lvlup.value.ToString() + "/" + max_requirement_int.ToString();
            lvlup.maxValue = max_requirement;
            level_number.text = lvl_number.ToString();
            levelrequirements.text = lvl_require;

            //SWITCH BETWEEN ABILITIES
            if (new_set == false)
            {
                for (int i = 0; i < limit; i++)
                {
                    cleave[i].enabled = true;

                    heart[i].enabled = false;


                    fireball[i].enabled = false;
                    //fireballText.enabled = false;

                    magic[i].enabled = false;
                }
            }
            else
            {
                for (int i = 0; i < 3; i++)
                {
                    cleave[i].enabled = false;


                    heart[i].enabled = true;

                    fireball[i].enabled = true;

                    magic[i].enabled = true;
                }
            }



            //TIMER FOR ABILITY COOLDOWN
            if (timerIsRunning_cleave)
            {

                if (timeRemaining_cleave > 0)
                {

                    timeRemaining_cleave -= Time.deltaTime;
                    int counter = (int)timeRemaining_cleave;

                    for (int i = 0; i < limit; i++)
                    {
                        cleaveText[i].enabled = true;
                        cleaveText[i].text = counter.ToString();
                    }
                }
                else
                {

                    timeRemaining_cleave = 11;

                    for (int i = 0; i < limit; i++)
                    {
                        cleaveText[i].enabled = false;
                    }

                    timerIsRunning_cleave = false;
                }

            }

            if (timerIsRunning_heart)
            {

                if (timeRemaining_heart > 0)
                {
                    timeRemaining_heart -= Time.deltaTime;
                    int counter = (int)timeRemaining_heart;
                    for (int i = 0; i < limit; i++)
                    {
                        heartText[i].enabled = true;
                        heartText[i].text = counter.ToString();
                    }
                }
                else
                {

                    timeRemaining_heart = 11;
                    for (int i = 0; i < limit; i++)
                    {
                        heartText[i].enabled = false;
                    }
                    timerIsRunning_heart = false;
                }

            }

            if (timerIsRunning_magic)
            {

                if (timeRemaining_magic > 0)
                {
                    timeRemaining_magic -= Time.deltaTime;
                    int counter = (int)timeRemaining_magic;
                    for (int i = 0; i < limit; i++)
                    {
                        magicText[i].enabled = true;
                        magicText[i].text = counter.ToString();
                    }
                }
                else
                {

                    timeRemaining_magic = 11;
                    for (int i = 0; i < limit; i++)
                    {
                        magicText[i].enabled = false;
                    }
                    timerIsRunning_magic = false;
                }

            }

            if (timerIsRunning_fireball)
            {

                if (timeRemaining_fireball > 0)
                {
                    timeRemaining_fireball -= Time.deltaTime;
                    int counter = (int)timeRemaining_fireball;
                    for (int i = 0; i < limit; i++)
                    {
                        fireballText[i].enabled = true;
                        fireballText[i].text = counter.ToString();
                    }
                }
                else
                {
                    timeRemaining_fireball = 11;
                    for (int i = 0; i < limit; i++)
                    {
                        fireballText[i].enabled = false;
                    }

                    timerIsRunning_fireball = false;
                }

            }

            //FOR PAUSING
            if (!paused)
            {
                Resume();
            }
            else
            {
                Pausing();
            }
        }


        //TIMER FOR SHOW REQUIREMENTS
        if (showrequirements)
        {
            if (timer_level > 0)
            {
                lvlrequirements.SetActive(true);
                timer_level -= Time.deltaTime;
            }
            else
            {
                timer_level = 10;
                lvlrequirements.SetActive(false);
                showrequirements = false;

            }
        }

        

       
    }

    //WHEN ABILITY BUTTON 1 IS CLICKED
    public void Special1Clicked()
    {
        //CLEAVE CLICKED
        if (timerIsRunning_fireball == false && new_set == true)
        {
            timerIsRunning_fireball = true;
        }
       
    }

    //WHEN ABILITY BUTTON 2 IS CLICKED
    public void Special2Clicked()
    {
        //CLEAVE CLICKED
        if (timerIsRunning_magic == false && new_set == true)
        {
            timerIsRunning_magic = true;
        }
    }


    //WHEN ABILITY BUTTON 3 IS CLICKED
    public void Special3Clicked()
    {
        //CLEAVE CLICKED
        if (timerIsRunning_cleave == false && new_set == false)
        {
            timerIsRunning_cleave = true;
        }
        else if (timerIsRunning_heart == false && new_set == true)
        {
            timerIsRunning_heart = true;
        }
    }

    //SWITCH TO NEW ABILITY SET
    public void newAbilities()
    {
        if (new_set == false)
        {
            new_set = true;
        }
        else
        {
            new_set = false;
        }

        Set();

    }

    //CLICK LEVEL UP BAR
    public void LVLbarClicked()
    {
        showrequirements = true;
    }

    //RESUME THE GAME
    public void Resume()
    {
        pauseUI.SetActive(false);
        Time.timeScale = 1.0f;
        paused = false;
    }

    //PAUSE THE GAME
    public void Pausing()
    {
        pauseUI.SetActive(true);
        Time.timeScale = 0.0f;
        paused = true;
    }
}
