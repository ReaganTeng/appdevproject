//using UnityEngine.EventSystems;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Joystick : MonoBehaviour
{
    //For joystick
    private Image joystick_background;
    private Image joystick;
    
    
    public GameObject character;

   



    float joystick_X;

    float joystick_Y;


    bool point;

    // Start is called before the first frame update
    void Start()
    {
        joystick_background = GetComponent<Image>();
        joystick = transform.GetChild(0).GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if(point == true )
        {
            joystick_X = (joystick.rectTransform.position.x - joystick_background.rectTransform.position.x) * Time.deltaTime;
            joystick_Y = (joystick.rectTransform.position.y - joystick_background.rectTransform.position.y) * Time.deltaTime;

            //MOVE THE PLAYER
            character.transform.Translate(new Vector3(joystick_X / 20, joystick_Y / 20, 0.0f));

        }

    }

    //For Joystick
    public void Dragging()
    {

        point = true;
        Vector3 newpos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1);
        joystick.rectTransform.position = newpos;

        
    }


    public void returnorigin()
    {
        joystick.rectTransform.anchoredPosition = new Vector3(0, 0, 1);
        point = false;
    }



}
