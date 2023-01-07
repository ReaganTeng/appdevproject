using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public MainGameVariables mainGame = new MainGameVariables();

    // Start is called before the first frame update
    void Start()
    {
        mainGame = GlobalStats.Instance.SavedWorld;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SavedStats()
    {
        GlobalStats.Instance.SavedWorld = mainGame;
    }
}
