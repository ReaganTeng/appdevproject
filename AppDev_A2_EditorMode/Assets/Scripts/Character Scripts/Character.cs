using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character
{
    public int Level;
    public int CurrentEXP;
    public int MaxEXP;
    public int CurrentHP;
    public int MaxHP;
    public int Strength;
    public int Intelligence;
    public int Agility;
    public int Vitality;
    public int Luck;

    public Hat hat = null;
    public Chest chest = null;
    public Weapon weapon = null;
    public Shoe shoe = null;

    public Character()
    {
        Level = 1;
        CurrentEXP = 0;
        MaxEXP = 100;
        CurrentHP = 100;
        MaxHP = 100;
        Strength = 10;
        Intelligence = 10;
        Agility = 10;
        Vitality = 10;
        Luck = 10;
    }

    public void UpdateStats()
    {
        int hatVit;
        int chestVit;
        int weaponVit;
        int shoeVit;
        int totalVitality;

        if (hat == null)
        {
            hatVit = 0;
        }
        else
        {
            hatVit = hat.extraVitality;
        }

        if (chest == null)
        {
            chestVit = 0;
        }
        else
        {
            chestVit = chest.extraVitality;
        }

        if (weapon == null)
        {
            weaponVit = 0;
        }
        else
        {
            weaponVit = weapon.extraVitality;
        }

        if (shoe == null)
        {
            shoeVit = 0;
        }
        else
        {
            shoeVit = shoe.extraVitality;
        }

        totalVitality = hatVit + chestVit + weaponVit + shoeVit;

        MaxEXP = 100 + (int)(((this.Level - 1) * 100) * 0.5);
        MaxHP = (int)((this.Vitality + totalVitality) * 10);
    }

    public void unequipHat()
    {
        Inventory.instance.HatList.Add(hat);
        hat = null;
    }

    public void unequipChest()
    {
        Inventory.instance.ChestList.Add(chest);
        chest = null;
    }

    public void unequipWeapon()
    {
        Inventory.instance.WeaponList.Add(weapon);
        weapon = null;
    }

    public void unequipShoe()
    {
        Inventory.instance.ShoeList.Add(shoe);
        shoe = null;
    }
}
