using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SaveAudio : MonoBehaviour
{

    public Slider Musicslider;
    public Slider Soundslider;
    public static float Music;
    public static float Sound;

    // Start is called before the first frame update
    void Start()
    {
        Music = GlobalStats.Instance.soundtrack;
        Sound = GlobalStats.Instance.sfx;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SaveVariables()
    {

       Music = Musicslider.value;
        GlobalStats.Instance.soundtrack = Music;

        Sound = Soundslider.value;
        GlobalStats.Instance.sfx = Sound;
    }
}
