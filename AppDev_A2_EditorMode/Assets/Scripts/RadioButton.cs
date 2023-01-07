using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;


public class RadioButton : MonoBehaviour
{
    public Toggle button;
    public Image slide;



    public void toggleOn()
    {
        if (button.isOn)
        {
            //slide.gameObject.SetActive(false);
        }
    }
}
