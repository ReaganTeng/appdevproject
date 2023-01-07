using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInScene : MonoBehaviour
{
    public static CharacterInScene instance;
    public static Character SceneCharacter;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        SceneCharacter = GlobalStats.Instance.SavedCharacter;
    }

    public void SaveStats()
    {
        SceneCharacter.UpdateStats();
        GlobalStats.Instance.SavedCharacter = SceneCharacter;
    }
}
