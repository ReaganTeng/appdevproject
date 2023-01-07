using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterScene : MonoBehaviour
{
    public Text levelText;
    public Text EXPText;
    public Text HPText;
    public Text strengthText;
    public Text intelligenceText;
    public Text agilityText;
    public Text vitalityText;
    public Text luckText;
    public bool isUpdate;
    // Start is called before the first frame update
    void Start()
    {
        isUpdate = true;
    }

    // Update is called once per frame
    void Update()
    {
        //update stats on stats overview
        if (isUpdate == true) //to prevent the game from updating the stats constantly
        {
            Hat CharacterHat;
            Chest CharacterChest;
            Weapon CharacterWeapon;
            Shoe CharacterShoe;

            if (CharacterInScene.SceneCharacter.hat == null)
            {
                CharacterHat = new Hat();
            }
            else
            {
                CharacterHat = CharacterInScene.SceneCharacter.hat;
            }

            if (CharacterInScene.SceneCharacter.chest == null)
            {
                CharacterChest = new Chest();
            }
            else
            {
                CharacterChest = CharacterInScene.SceneCharacter.chest;
            }

            if (CharacterInScene.SceneCharacter.weapon == null)
            {
                CharacterWeapon = new Weapon();
            }
            else
            {
                CharacterWeapon = CharacterInScene.SceneCharacter.weapon;
            }

            if (CharacterInScene.SceneCharacter.shoe == null)
            {
                CharacterShoe = new Shoe();
            }
            else
            {
                CharacterShoe = CharacterInScene.SceneCharacter.shoe;
            }

            int Strength = CharacterHat.extraStrength + CharacterChest.extraStrength + CharacterWeapon.extraStrength + CharacterShoe.extraStrength;
            int Intelligence = CharacterHat.extraIntelligence + CharacterChest.extraIntelligence + CharacterWeapon.extraIntelligence + CharacterShoe.extraIntelligence;
            int Agility = CharacterHat.extraAgility + CharacterChest.extraAgility + CharacterWeapon.extraAgility + CharacterShoe.extraAgility;
            int Vitality = CharacterHat.extraVitality + CharacterChest.extraVitality + CharacterWeapon.extraVitality + CharacterShoe.extraVitality;
            int Luck = CharacterHat.extraLuck + CharacterChest.extraLuck + CharacterWeapon.extraLuck + CharacterShoe.extraLuck;


            levelText.text = "Level: " + CharacterInScene.SceneCharacter.Level;
            HPText.text = "Health: " + CharacterInScene.SceneCharacter.CurrentHP + "/" + CharacterInScene.SceneCharacter.MaxHP;
            EXPText.text = "EXP: " + CharacterInScene.SceneCharacter.CurrentEXP + "/" + CharacterInScene.SceneCharacter.MaxEXP;

            strengthText.text = "Strength: " + CharacterInScene.SceneCharacter.Strength;
            if(Strength > 0)
            {
                strengthText.text += " <color=green>+" + Strength + "</color>";
            }

            intelligenceText.text = "Intelligence: " + CharacterInScene.SceneCharacter.Intelligence;
            if (Intelligence > 0)
            {
                intelligenceText.text += " <color=green>+" + Intelligence + "</color>";
            }

            agilityText.text = "Agility: " + CharacterInScene.SceneCharacter.Agility;
            if (Agility > 0)
            {
                agilityText.text += " <color=green>+" + Agility + "</color>";
            }

            vitalityText.text = "Vitality: " + CharacterInScene.SceneCharacter.Vitality;
            if (Vitality > 0)
            {
                vitalityText.text += " <color=green>+" + Vitality + "</color>";
            }

            luckText.text = "Luck: " + CharacterInScene.SceneCharacter.Luck;
            if (Luck > 0)
            {
                luckText.text += " <color=green>+" + Luck + "</color>";
            }

            isUpdate = false;
        }
    }

    public void GoToInventory()
    {
        SceneManager.LoadScene("Inventory");
    }

    public void GoToMainGame()
    {
        SceneManager.LoadScene("Main Game");
    }

    public void GoToMoreDetails()
    {
        SceneManager.LoadScene("More Details");
    }
}