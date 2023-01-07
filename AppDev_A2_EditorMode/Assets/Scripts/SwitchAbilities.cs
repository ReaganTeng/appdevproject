using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchAbilities : MonoBehaviour
{
    public Image fireball;
    public Image heart;
    public Image cleave;
    public Image magic;

    bool new_set;
    // Start is called before the first frame update
    void Start()
    {
        new_set = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (new_set == false)
        {
            cleave.enabled = true;
            heart.enabled = false;
            fireball.enabled = false;
            magic.enabled = false;

        }
        else

        {
            cleave.enabled = false;
            heart.enabled = true;
            fireball.enabled = true;
            magic.enabled = true;

        }
    }

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
    }

}
