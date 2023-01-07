using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonControl : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
      
    }


    public void PlayButtonClicked()
    {
        SceneManager.LoadScene("Main Game");
    }

    public void OptionsButtonClicked()
    {
        SceneManager.LoadScene("Audio or Visual");
    }


    public static string PreviousLevel { get; private set; }

    public void GoBackFromOptions()
    {
        
        PreviousLevel = gameObject.scene.name;
    }


    public void AudioClicked()
    {
        SceneManager.LoadScene("Audio");
    }


    public void DisplayClicked()
    {
        SceneManager.LoadScene("Display");
    }


    public void goBackfromAV()
    {
        SceneManager.LoadScene("Audio or Visual");
       
    }

    public void goToCharacterScreen ()
    {
        SceneManager.LoadScene("Character");
    }

    public void goToMainGame()
    {
        SceneManager.LoadScene("Main Game");

    }

    public void goToMenu()
    {
        SceneManager.LoadScene("Main Menu");

    }




}
