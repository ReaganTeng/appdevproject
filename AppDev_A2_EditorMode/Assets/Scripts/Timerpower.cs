using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timerpower : MonoBehaviour
{
    // Start is called before the first frame update
    public float timeRemaining = 10;
    public int timeRemainingint = 10;

    bool timerIsRunning = false;
    public GameObject setpoweractive;
    public Text powerTimer;

    void Start()
    {
        //timerIsRunning = true;
        
        //timerIsRunning = true;
    }

   
    void Update()
    {

        if (timerIsRunning)
        {
            setpoweractive.SetActive(true);
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;

                //if (timeRemaining > 0 && timeRemaining < 0.01 ||
                //    timeRemaining > 1 && timeRemaining < 1.01 ||
                //    timeRemaining > 2 && timeRemaining < 2.01 ||
                //    timeRemaining > 3 && timeRemaining < 3.01 ||
                //    timeRemaining > 4 && timeRemaining < 4.01 ||
                //    timeRemaining > 5 && timeRemaining < 5.01 ||
                //    timeRemaining > 6 && timeRemaining < 6.01 ||
                //    timeRemaining > 7 && timeRemaining < 7.01 ||
                //    timeRemaining > 8 && timeRemaining < 8.01 ||
                //    timeRemaining > 9 && timeRemaining < 9.01)
                //{
                   timeRemainingint = Mathf.FloorToInt((timeRemaining % 60));
                //}

                //convert timeremaining to text
                powerTimer.text = timeRemainingint.ToString();
            }
            else
            {
                timerIsRunning = false;
            }
        }
        else
        {
            setpoweractive.SetActive(false);

        }
    }


    public void updateTimer()
    {
        timerIsRunning = true;

    }
}
