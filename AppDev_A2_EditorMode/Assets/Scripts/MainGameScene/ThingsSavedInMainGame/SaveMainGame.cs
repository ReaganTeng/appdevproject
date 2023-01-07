using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveMainGame : MonoBehaviour
{
    public static Vector3 CXY;



    public Slider slider;
    public Slider slider2;
    public static float Health;
    public static float LVL;



    public Toggle save_point;
    public static bool saved;


    // Start is called before the first frame update
    void Start()
    {
        CXY = GlobalStats.Instance.location;
        CXY.z = -10;

        Health = GlobalStats.Instance.healthlvl;
        LVL = GlobalStats.Instance.lvl;

        saved = GlobalStats.Instance.is_it_saved;
        
    }


    public void SaveVariables()
    {
        CXY = Camera.main.transform.position;
        GlobalStats.Instance.location = CXY;

        saved = save_point.GetComponent<Toggle>().isOn;
        GlobalStats.Instance.is_it_saved = saved;

        Health = slider.value;
        GlobalStats.Instance.healthlvl = Health;

       
        LVL = slider2.value;
        GlobalStats.Instance.lvl = LVL;

    }
}
