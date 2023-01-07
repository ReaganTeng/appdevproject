using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SaveDisplay : MonoBehaviour
{
    public Toggle enablehp;
    public Toggle enablemap;
    public Toggle enablelvl;

    public static bool hp_exist;
    public static bool map_exist;
    public static bool lvl_exist;

    public Toggle small_con;
    public Toggle medium_con;
    public Toggle large_con;

    public static bool small_exist;
    public static bool large_exist;
    public static bool medium_exist;



    // Start is called before the first frame update
    void Start()
    {

        hp_exist = GlobalStats.Instance.healthlvl_present;
        lvl_exist = GlobalStats.Instance.lvl_present;
        map_exist = GlobalStats.Instance.minimap_present;

        small_exist = GlobalStats.Instance.small_present;
        medium_exist = GlobalStats.Instance.medium_present;
        large_exist = GlobalStats.Instance.large_present;

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SaveVariables()
    {
        //FOR HUDS
        hp_exist = enablehp.GetComponent<Toggle>().isOn;
        GlobalStats.Instance.healthlvl_present = hp_exist;

        map_exist = enablemap.GetComponent<Toggle>().isOn;
        GlobalStats.Instance.minimap_present = map_exist;

        lvl_exist = enablelvl.GetComponent<Toggle>().isOn;
        GlobalStats.Instance.lvl_present = lvl_exist;


        //FOR CONTROL SIZE
        small_exist = small_con.GetComponent<Toggle>().isOn;
        GlobalStats.Instance.small_present = small_exist;

        medium_exist = medium_con.GetComponent<Toggle>().isOn;
        GlobalStats.Instance.medium_present = medium_exist;

        large_exist = large_con.GetComponent<Toggle>().isOn;
        GlobalStats.Instance.large_present = large_exist;
    }
}
