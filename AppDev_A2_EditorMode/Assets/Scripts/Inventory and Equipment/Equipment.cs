using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : ScriptableObject
{
    public enum Rarity
    {
        COMMON,
        UNCOMMON,
        RARE,
    }

    public Rarity rarity = Rarity.COMMON;
    public string Name = "";
    public int extraStrength = 0;
    public int extraIntelligence = 0;
    public int extraAgility = 0;
    public int extraVitality = 0;
    public int extraLuck = 0;
    public Sprite icon = null;
}
